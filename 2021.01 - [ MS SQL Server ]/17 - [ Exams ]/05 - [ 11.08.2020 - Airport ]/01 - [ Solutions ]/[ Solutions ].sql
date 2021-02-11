-- CREATE DATABASE Airport
-- DROP DATABASE Airport
-- USE Airport
-- USE SoftUni

--1
CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL,
	
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL,
	FlightId INT REFERENCES Flights(Id) NOT NULL,
	LuggageId INT REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL (15, 2) NOT NULL
)

--2
INSERT INTO 
	Planes
	([Name], Seats, [Range])
	VALUES
	('Airbus 336', 112, 5132),
	('Airbus 330', 432, 5325),
	('Boeing 369', 231, 2355),
	('Stelt 297', 254, 2143),
	('Boeing 338', 165, 5111),
	('Airbus 558', 387, 1342),
	('Boeing 128', 345, 5541)

INSERT INTO 
	LuggageTypes
	([Type])
	VALUES
	('Crossbody Bag'),
	('School Backpack'),
	('Shoulder Bag')

--3
UPDATE
	Tickets
	SET Price = Price + (Price * 0.14)
	WHERE FlightId = 41

--4

DELETE 
	Tickets 
	WHERE FlightId = 30

DELETE 
	Flights 
	WHERE Destination = 'Ayn Halagim'

--5
SELECT 
	* FROM Planes 
	WHERE [Name] LIKE '%tr%' 
	ORDER BY ID, [Name], Seats, [Range]

--6
SELECT 
	FlightId, 
	SUM(Price) AS Price
	FROM Tickets
	GROUP BY FlightId
	ORDER BY SUM(Price) DESC, FlightId

--7
SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name],
	Origin,
	Destination
	FROM Passengers P
	JOIN Tickets T ON T.PassengerId = p.Id
	JOIN Flights F ON F.Id = T.FlightId
	ORDER BY CONCAT(FirstName, ' ', LastName), Origin, Destination

--8
SELECT 
	FirstName,
	LastName,
	Age
	FROM Passengers P
	LEFT JOIN Tickets T ON T.PassengerId = P.Id
	WHERE T.Id IS NULL
	ORDER BY Age DESC, FirstName, LastName

--9
SELECT 
	CONCAT(P.FirstName, ' ', P.LastName) AS [Full Name],
	PL.[Name],
	CAST(F.Origin + ' - ' + F.[Destination] AS NVARCHAR(MAX)) AS Trip,
	LT.[Type]
	FROM Passengers P
	JOIN Tickets T ON T.PassengerId = P.Id
	JOIN Flights F ON F.Id = T.FlightId
	JOIN Planes PL ON PL.Id = F.PlaneId
	JOIN Luggages L ON L.Id = T.LuggageId
	JOIN LuggageTypes LT ON LT.Id = L.LuggageTypeId
	ORDER BY [Full Name], PL.[Name], F.Origin, F.Destination, LT.[Type]

--10
SELECT
	PL.[Name],
	PL.Seats,
	COUNT(T.Id) AS [Count]
	FROM Planes PL
	LEFT JOIN Flights F ON F.PlaneId = PL.Id
	LEFT JOIN Tickets T ON T.FlightId = F.Id
	GROUP BY F.PlaneId, PL.[Name], PL.Seats
	ORDER BY COUNT(T.Id) DESC, PL.[Name], PL.Seats

--11
DECLARE @origin VARCHAR(50) = 'Urug'
DECLARE @destination VARCHAR(50) = 'Velykyy Burluk'
DECLARE @peopleCount INT = 33

IF(@peopleCount <= 0)
	THROW 50001, 'Invalid people count!', 1

DECLARE @flightId INT = (SELECT TOP 1 Id FROM Flights WHERE Origin = @origin AND Destination = @destination)

IF(@flightId IS NULL)
	THROW 50002, 'Invalid flight!', 1

DECLARE @pricePerPerson DECIMAL(15, 2) = (SELECT TOP 1 Price FROM Tickets WHERE FlightId = @flightId)

DECLARE @totalPrice DECIMAL(15, 2) = @pricePerPerson * @peopleCount

DECLARE @output NVARCHAR(MAX) = 'Total price ' + CAST(@totalPrice AS NVARCHAR(MAX))

PRINT @output

SELECT * FROM Flights
SELECT * FROM Tickets WHERE FlightId = 2

CREATE OR ALTER FUNCTION udf_CalculateTickets (@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	
	DECLARE @error NVARCHAR(MAX)

	IF(@peopleCount <= 0)
	BEGIN
		SET @error = 'Invalid people count!'
		RETURN @error;
	END
	
	DECLARE @flightId INT = (SELECT TOP 1 Id FROM Flights WHERE Origin = @origin AND Destination = @destination)
	
	IF(@flightId IS NULL)
	BEGIN
		SET @error = 'Invalid flight!'
		RETURN @error;
	END

	DECLARE @pricePerPerson DECIMAL(15, 2) = (SELECT TOP 1 Price FROM Tickets WHERE FlightId = @flightId)
	
	DECLARE @totalPrice DECIMAL(15, 2) = @pricePerPerson * @peopleCount
	
	DECLARE @output NVARCHAR(MAX) = 'Total price ' + CAST(@totalPrice AS NVARCHAR(MAX))
	
	RETURN @output
END

/*

Create a user defined function, named udf_CalculateTickets(@origin, @destination, @peopleCount) 
that receives an origin (town name), destination (town name) and people count.

The function must return the total price in format "Total price {price}"
•	If people count is less or equal to zero return – "Invalid people count!"
•	If flight is invalid return – "Invalid flight!"
Example:
Query
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
Output
Total price 2419.89

Query
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
Output
Invalid people count!

Query
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)
Output
Invalid flight!


*/

SELECT * FROM Flights
SELECT * FROM Tickets
SELECT * FROM Passengers
SELECT * FROM Planes
SELECT * FROM Luggages
SELECT * FROM LuggageTypes