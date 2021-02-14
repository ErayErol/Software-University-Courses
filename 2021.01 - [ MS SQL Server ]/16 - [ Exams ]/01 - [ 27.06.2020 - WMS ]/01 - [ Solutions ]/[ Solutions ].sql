-- 1
CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL,
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' 
	CHECK([Status] IN ('Pending', 'In Progress', 'Finished')) NOT NULL,
	ClientId INT REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL,
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL (6, 2) CHECK(Price > 0) NOT NULL,
	VendorId INT REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 CHECK(StockQty >= 0) NOT NULL,
)

CREATE TABLE OrderParts
(	
	OrderId INT REFERENCES Orders(OrderId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL,

	PRIMARY KEY(OrderId, PartId) 
)

CREATE TABLE PartsNeeded
(	
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0) NOT NULL,

	PRIMARY KEY(JobId, PartId)
)

-- 2
INSERT INTO 
	Clients 
	(FirstName, LastName, Phone) 
	VALUES
	('Teri', 'Ennaco', '570-889-5187'),
	('Merlyn', 'Lawler', '201-588-7810'),
	('Georgene', 'Montezuma', '925-615-5185'),
	('Jettie', 'Mconnell', '908-802-3564'),
	('Lemuel', 'Latzke', '631-748-6479'),
	('Melodie', 'Knipp', '805-690-1682'),
	('Candida', 'Corbley', '908-275-8357')

INSERT INTO 
	Parts 
	(SerialNumber, [Description], Price, VendorId) 
	VALUES
	('WP8182119', 'Door Boot Seal', 117.86, 2),
	('W10780048', 'Suspension Rod', 42.81, 1),
	('W10841140', 'Silicone Adhesive ', 6.77, 4),
	('WPY055980', 'High Temperature Adhesive', 13.94, 3)

-- 3
UPDATE 
	Jobs
	SET MechanicId = 3, [Status] = 'In Progress'
	WHERE [Status] = 'Pending'

--4
DELETE 
	FROM OrderParts 
	WHERE OrderId = 19

DELETE 
	FROM Orders 
	WHERE OrderId = 19

--5
SELECT 
	CONCAT(M.FirstName, ' ', M.LastName) AS [Full Name],
	J.[Status],
	J.IssueDate
	FROM Jobs J 
	JOIN Mechanics M ON M.MechanicId = J.MechanicId 
	ORDER BY M.MechanicId, J.IssueDate, J.JobId

--6
SELECT 
	CONCAT(C.FirstName, ' ', C.LastName) AS Client,
	DATEDIFF(DAY, J.IssueDate, CONVERT(Datetime, '2017-04-24 18:01:00', 120)) AS [Days going],
	J.[Status]
	FROM Jobs J 
	JOIN Clients C ON C.ClientId = J.ClientId 
	WHERE J.[Status] <> 'Finished'
	ORDER BY [Days going] DESC, C.ClientId

--7
SELECT 
	CONCAT(M.FirstName, ' ', M.LastName) AS [Mechanic],
	AVG(DATEDIFF(DAY, J.IssueDate, J.FinishDate))  AS [Average Days]
	FROM Jobs J 
	JOIN Mechanics M ON M.MechanicId = J.MechanicId
	GROUP BY J.MechanicId, M.FirstName, M.LastName
	ORDER BY J.MechanicId

--8
SELECT 
	CONCAT(M.FirstName, ' ', M.LastName) AS [Full Name]
	FROM Mechanics M
	WHERE 'Finished' = 
	  ALL (SELECT [Status] FROM Jobs J WHERE J.MechanicId = M.MechanicId AND J.[Status] <> 'Finished' OR
	  NOT NULL = ALL(SELECT J.FinishDate FROM Jobs J WHERE J.MechanicId = M.MechanicId))

--9
SELECT
	J.JobId,
	ISNULL(SUM(P.Price * OP.Quantity), 0) AS Total
	FROM Jobs J
	LEFT JOIN Orders O ON O.JobId = J.JobId
	LEFT JOIN OrderParts OP ON OP.OrderId = O.OrderId
	LEFT JOIN Parts P ON P.PartId = OP.PartId
	WHERE J.[Status] = 'Finished'
	GROUP BY J.JobId
	ORDER BY Total DESC, J.JobId
	
--10
SELECT 
	P.PartId,
	P.[Description],
	PN.Quantity,
	P.StockQty,
	0
	FROM PartsNeeded PN
	LEFT JOIN Jobs J ON J.JobId = PN.JobId
	LEFT JOIN Parts P ON P.PartId = PN.PartId
	LEFT JOIN Orders O ON O.JobId = J.JobId
	WHERE J.[Status] <> 'Finished' AND PN.Quantity > P.StockQty AND O.Delivered IS NULL
	ORDER BY P.PartId

--11
CREATE PROC usp_PlaceOrder (@jobId INT, @partSerialNumber VARCHAR(50), @quantity INT)
AS
BEGIN 
	
	IF(@quantity <= 0)
		THROW 50012, 'Part quantity must be more than zero!', 1
	ELSE IF NOT EXISTS(SELECT JobId FROM Jobs WHERE JobId = @jobId)
		THROW 50013, 'Job not found!', 1
	ELSE IF EXISTS(SELECT Status FROM Jobs WHERE JobId = @jobId AND Status = 'Finished')
		THROW 50011, 'This job is not active!', 1
	ELSE IF NOT EXISTS(SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)
		THROW 50014, 'Part not found!', 1

	DECLARE @jobStatus VARCHAR(50) = (SELECT [Status] FROM Jobs WHERE JobId = @jobId)
	DECLARE @isJobIdExist INT = (SELECT JobId FROM Jobs WHERE JobId = @jobId)
	DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)
	DECLARE @orderId INT = (SELECT OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL)

	IF (@orderId IS NULL)
	BEGIN
		INSERT INTO Orders(JobId, IssueDate, Delivered) VALUES (@jobId, NULL, 0)
	END

	SET @orderId = (SELECT OrderId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL)
	
	DECLARE @orderPartQty INT = (SELECT Quantity FROM OrderParts WHERE OrderId = @orderId AND PartId = @partId)
	IF (@orderPartQty IS NULL)
	BEGIN
		INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES (@orderId, @partId, @quantity)
	END
	ELSE
	BEGIN
		UPDATE 
			OrderParts 
			SET Quantity += @quantity 
			WHERE OrderId = @orderId AND PartId = @partId
	END

END

--12
CREATE FUNCTION udf_GetCost (@jobsId INT)
RETURNS DECIMAL (15,2)
AS 
BEGIN

	DECLARE @RESULT DECIMAL (15,2);
	
	SET @RESULT = (SELECT 
					ISNULL(SUM(op.Quantity * p.Price), 0) AS [Sum] 
					FROM Jobs j
					LEFT JOIN Orders o ON o.JobId = j.JobId
					LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
					LEFT JOIN Parts p ON p.PartId = op.PartId
					WHERE j.JobId = @jobsId
					GROUP BY j.JobId)
	
	RETURN @RESULT

END