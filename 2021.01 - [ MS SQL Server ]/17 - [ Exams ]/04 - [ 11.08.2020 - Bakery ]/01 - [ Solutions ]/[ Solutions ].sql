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
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')) NOT NULL, 
	Age INT NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	CountryId INT REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE NOT NULL,
	[Description] NVARCHAR(250) NOT NULL,
	Recipe NVARCHAR(MAX) NOT NULL,
	Price MONEY CHECK(Price > 0) NOT NULL 
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Recipe NVARCHAR(MAX),
	Rate DECIMAL(4, 2) CHECK(Rate BETWEEN 0 AND 10) NOT NULL,
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
	C.Age, 
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
	Age,
	PhoneNumber
	FROM Customers
	WHERE AGE >= 21 AND (FirstName LIKE '%an%' OR PhoneNumber LIKE '%38') AND CountryId <> 31
	ORDER BY FirstName, AGE DESC

--9
SELECT 
	D.[Name] AS DistributorName,
	I.[Name] AS IngredientName,
	P.[Name] AS ProductName,
	AVG(F.Rate) AS AverageRate
	FROM Distributors D 
	LEFT JOIN Ingredients I ON I.DistributorId = D.Id
	LEFT JOIN ProductsIngredients [PI] ON [PI].IngredientId = I.Id
	LEFT JOIN Products P ON P.Id = [PI].ProductId
	LEFT JOIN Feedbacks F ON F.ProductId = P.Id
	GROUP BY D.[Name], I.[Name], P.[Name]
	HAVING AVG(F.Rate) BETWEEN 5 AND 8
	ORDER BY D.[Name], I.[Name], P.[Name]

--10
SELECT 
	K.CountryName, 
	K.DistributorName
	FROM(
		SELECT
		C.[Name] AS CountryName,
		D.[Name] AS DistributorName,
		COUNT(I.Id) AS [Counter],
		DENSE_RANK() OVER (PARTITION BY C.[Name] ORDER BY COUNT(I.Id) DESC) AS [Rank]
		FROM Distributors D 
		LEFT JOIN Ingredients I ON I.DistributorId = D.Id 
		JOIN Countries C ON C.Id = D.CountryId
		GROUP BY C.[Name], D.[Name]
		) AS K
	WHERE k.[Rank] = 1
	ORDER BY K.CountryName, K.DistributorName

--11
CREATE VIEW v_UserWithCountries AS
SELECT 
	CONCAT(FirstName, ' ', LastName) AS CustomerName, 
	Age,
	Gender,
	CN.[Name]
	FROM Customers CT 
	LEFT JOIN Countries CN ON CN.Id = CT.CountryId 

--12
CREATE TRIGGER tr_DeleteAllProducts ON Products INSTEAD OF DELETE
AS
BEGIN

	DECLARE @productId INT = (SELECT Id FROM deleted)

	DELETE
		FROM Feedbacks 
		WHERE ProductId = @productId

	DELETE
		FROM ProductsIngredients 
		WHERE ProductId = @productId

	DELETE
		FROM Products 
		WHERE Id = @productId

END