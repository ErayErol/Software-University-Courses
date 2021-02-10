--1
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')) NOT NULL, --CHECK
	AGE INT NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	CountryId INT REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[Description] NVARCHAR(250) NOT NULL,
	Recipe NVARCHAR(MAX) NOT NULL,
	Price MONEY CHECK(Price > 0) NOT NULL --CHECK
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Recipe NVARCHAR(MAX),
	Rate DECIMAL(4, 2) CHECK(Rate BETWEEN 0 AND 10) NOT NULL, --CHECK
	ProductId INT REFERENCES Products(Id) NOT NULL,
	CustomerId INT REFERENCES Customers(Id) NOT NULL,
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	AddressText NVARCHAR(30) NOT NULL,
	Summary NVARCHAR(200) NOT NULL,
	CountryId INT REFERENCES Countries(Id) NOT NULL,
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	OriginCountryId INT REFERENCES Countries(Id) NOT NULL,
	DistributorId INT REFERENCES Distributors(Id) NOT NULL
)

CREATE TABLE ProductsIngredients
(
	ProductId INT REFERENCES Products(Id) NOT NULL,
	IngredientId INT REFERENCES Ingredients(Id) NOT NULL

	PRIMARY KEY(ProductId, IngredientId)
)

--2
INSERT INTO 
Distributors ([Name], CountryId, AddressText, Summary) 
VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St',	'Customer loyalty'),
('Kitchen People',	1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO 
Customers
(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes',	'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--3
UPDATE
	Ingredients
	SET DistributorId = 35
	WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE
	Ingredients
	SET OriginCountryId = 14
	WHERE OriginCountryId = 8

--4
DELETE
	FROM Feedbacks
	WHERE CustomerId = 14 OR ProductId = 5

--5
SELECT 
	[Name],
	Price,
	Description
	FROM Products
	ORDER BY Price DESC, [Name]

--6

SELECT 
	F.ProductId, 
	F.Rate, 
	F.[Description], 
	F.CustomerId, 
	C.AGE, 
	C.Gender 
	FROM Feedbacks F 
	JOIN Customers C ON C.Id = F.CustomerId 
	WHERE F.Rate < 5.0 
	ORDER BY F.ProductId DESC, F.Rate

--7
SELECT 
	CONCAT(C.FirstName, ' ', C.LastName) AS CustomerName,
	C.PhoneNumber,
	C.Gender
	FROM Feedbacks F 
	RIGHT JOIN Customers C ON C.Id = F.CustomerId 
	WHERE F.Id IS NULL 
	ORDER BY C.Id

--8

SELECT 
	FirstName,
	AGE,
	PhoneNumber
	FROM Customers
	WHERE AGE >= 21 AND (FirstName LIKE '%an%' OR PhoneNumber LIKE '%38') AND CountryId <> 31
	ORDER BY FirstName, AGE DESC

--9


--10

--11



SELECT * FROM Distributors
SELECT * FROM Ingredients
SELECT * FROM Countries
SELECT * FROM Products 
SELECT * FROM Feedbacks
SELECT * FROM ProductsIngredients
SELECT * FROM Customers

--12

CREATE TRIGGER tr_DeleteAllRelationship ON Accounts FOR DELETE
AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
			SELECT i.Id, d.Balance, i.Balance
			FROM inserted i
			JOIN deleted d ON d.Id = i.Id
			WHERE i.Balance != d.Balance;
END

/*
Create a trigger that deletes all of the relations of a product upon its deletion. 

*/