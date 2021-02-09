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
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK ([Status] IN ('Pending', 'In Progress','Finished')),
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATETIME NOT NULL,
	FinishDate DATETIME
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	IssueDate DATETIME,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL (6, 2) CHECK (Price > 0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId	INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId	INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK (Quantity > 0)

	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId	INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId	INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK (Quantity > 0)

	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)

-- 2
INSERT INTO 
	Clients (FirstName, LastName, Phone) 
VALUES
	('Teri', 'Ennaco', '570-889-5187'),
	('Merlyn', 'Lawler', '201-588-7810'),
	('Georgene', 'Montezuma', '925-615-5185'),
	('Jettie', 'Mconnell', '908-802-3564'),
	('Lemuel', 'Latzke', '631-748-6479'),
	('Melodie', 'Knipp', '805-690-1682'),
	('Candida', 'Corbley', '908-275-8357')

INSERT INTO 
	Parts (SerialNumber, [Description], Price, VendorId) 
VALUES
	('WP8182119', 'Door Boot Seal', 117.86, 2),
	('W10780048', 'Suspension Rod', 42.81, 1),
	('W10841140', 'Silicone Adhesive ', 6.77, 4),
	('WPY055980', 'High Temperature Adhesive', 13.94, 3)

-- 3
UPDATE 
	Jobs
SET 
	MechanicId = 3, [Status] = 'In Progress'
WHERE 
	[Status] = 'Pending'

--4
DELETE FROM 
	OrderParts 
WHERE 
	OrderId = 19
DELETE FROM 
	Orders 
WHERE 
	OrderId = 19

--5
SELECT 
	m.FirstName + ' ' + m.LastName AS [Mechanic], j.[Status], j.IssueDate
FROM 
	Mechanics m
JOIN 
	Jobs j ON j.MechanicId = m.MechanicId
ORDER BY 
	m.MechanicId, j.IssueDate, j.JobId

--6
SELECT 
	c.FirstName + ' ' + c.LastName AS [Client],
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	j.[Status]
FROM 
	Clients c
LEFT JOIN 
	Jobs j ON j.ClientId = c.ClientId
WHERE 
	j.[Status] <> 'Finished'
ORDER BY 
	[Days going] DESC, c.ClientId

--7
SELECT 
	m.FirstName + ' ' + m.LastName AS [Mechanic],
	AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS [Average Days]
FROM 
	Jobs j
JOIN 
	Mechanics m ON m.MechanicId = j.MechanicId
GROUP BY 
	m.MechanicId, m.FirstName, m.LastName

--8
SELECT 
	m.FirstName + ' ' +  m.LastName AS Available
FROM 
	Mechanics AS m
WHERE 
	'Finished' = ALL(SELECT j.[Status] FROM Jobs j WHERE j.MechanicId = m.MechanicId) OR
	NOT NULL = ALL(SELECT j.FinishDate FROM Jobs j WHERE j.MechanicId = m.MechanicId)
ORDER BY m.MechanicId

--9
SELECT 
	j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
FROM 
	Jobs j
LEFT JOIN Orders o ON j.JobId = o.JobId
LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
LEFT JOIN Parts p ON p.PartId IN (op.PartId)
WHERE 
	j.[Status] = 'Finished'
GROUP BY 
	j.JobId
ORDER BY 
	Total DESC, j.JobId

--10
SELECT 
  p.PartId, 
  p.[Description], 
  pn.Quantity AS [Required], 
  p.StockQty AS [In Stock],
  CASE 
    WHEN ISNULL(o.Delivered, 0) = 'False' THEN 0 
    ELSE NULL 
  END AS [Ordered]
FROM 
	PartsNeeded pn
LEFT JOIN Jobs j ON j.JobId = pn.JobId
LEFT JOIN Parts p ON p.PartId = pn.PartId
LEFT JOIN Orders o On o.JobId = j.JobId
WHERE 
  j.Status <> 'Finished' AND 
  pn.Quantity - p.StockQty > 0 AND 
  o.Delivered IS NULL
ORDER BY 
	p.PartId

--11
select top 3 * from Jobs
select top 3 * from Orders
select top 3 * from OrderParts
select top 3 * from Parts

CREATE OR ALTER PROC usp_PlaceOrder (@jobId INT, @partSerialNumber VARCHAR(50), @quantity INT)
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
		UPDATE OrderParts SET Quantity += @quantity WHERE OrderId = @orderId AND PartId = @partId
	END

END

--12
CREATE FUNCTION udf_GetCost (@jobsId INT)
RETURNS DECIMAL (15,2)
AS 
BEGIN

	DECLARE @RESULT DECIMAL (15,2);
	
	SET @RESULT =
	(
		SELECT 
			ISNULL(SUM(op.Quantity * p.Price), 0) AS [Sum] 
		FROM 
			Jobs j
		LEFT JOIN Orders o ON o.JobId = j.JobId
		LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
		LEFT JOIN Parts p ON p.PartId = op.PartId
		WHERE 
			j.JobId = @jobsId
		GROUP BY
			j.JobId
	)
	RETURN @RESULT

END