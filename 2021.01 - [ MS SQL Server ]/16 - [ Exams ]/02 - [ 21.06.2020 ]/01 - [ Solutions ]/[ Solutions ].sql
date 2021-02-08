-- 1
CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	CountryCode NCHAR(2) CHECK(LEN(CountryCode) = 2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL (15,2) 
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL (15,2) NOT NULL,
	[Type] VARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATETIME NOT NULL,
	constraint check_dates check (BookDate < ArrivalDate),
	ArrivalDate DATETIME NOT NULL,
	constraint check_dates2 check (ArrivalDate < ReturnDate),
	ReturnDate DATETIME NOT NULL,
	CancelDate DATETIME
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(20),
	LastName VARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATETIME NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE AccountsTrips
(
	AccountId	INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId	INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL

	CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId, TripId)
)

--2
INSERT INTO Accounts 
(FirstName, MiddleName, LastName, CityId, BirthDate, Email) 
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips 
(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) 
VALUES
(101, '2015-04-12',	'2015-04-14', '2015-04-20',	'2015-02-02'),
(102, '2015-07-07',	'2015-07-15', '2015-07-22',	'2015-04-29'),
(103, '2013-07-17',	'2013-07-23', '2013-07-24',	NULL),
(104, '2012-03-17',	'2012-03-31', '2012-04-01',	'2012-01-10'),
(109, '2017-08-07',	'2017-08-28', '2017-08-29',	NULL)

--3
UPDATE Rooms 
SET Price = Price + (Price * 0.14)
WHERE HotelId IN (5,7,9)

--4
DELETE FROM AccountsTrips WHERE AccountId = 47
DELETE FROM Accounts WHERE Id = 47

--5
SELECT 
	A.FirstName, 
	A.LastName,
	FORMAT (A.BirthDate, 'MM-dd-yyyy') AS BirthDate,
	C.[Name] AS Hometown,
	A.Email
FROM 
	Accounts A
LEFT JOIN 
	Cities C ON C.Id = A.CityId
WHERE 
	A.Email LIKE 'E%'
ORDER BY 
	C.[Name] 

--6
SELECT C.[Name], COUNT(CityId) AS Hotels FROM Hotels H JOIN Cities C ON C.Id = H.CityId GROUP BY C.[Name] ORDER BY COUNT(CityId) DESC, C.[Name]

--7
SELECT AT.AccountId, A.FirstName + ' ' + A.LastName AS [FullName], 
	MAX(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS LongestTrip, MIN(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS ShortestTrip
FROM AccountsTrips AT
LEFT JOIN Accounts A ON A.Id = AT.AccountId
LEFT JOIN Trips T ON T.Id = AT.TripId
WHERE A.MiddleName IS NULL AND T.CancelDate IS NULL
GROUP BY AT.AccountId, A.FirstName, A.LastName
ORDER BY LongestTrip desc, ShortestTrip

--8
SELECT TOP 10
	A.CityId, C.[Name], C.CountryCode, COUNT(CityId) AS Accounts 
FROM 
	Accounts A
JOIN 
	Cities C ON C.Id = A.CityId
GROUP BY 
	A.CityId, C.[Name], C.CountryCode
ORDER BY 
	Accounts DESC

--9
SELECT AT.AccountId, A.Email, C.[Name], COUNT(AT.AccountId) AS Trips
FROM AccountsTrips AT
JOIN Accounts A ON A.Id = AT.AccountId
JOIN Trips T ON T.Id = AT.TripId
JOIN Rooms R ON R.Id = T.RoomId
JOIN Hotels H ON H.Id = R.HotelId AND H.CityId = A.CityId
JOIN Cities C ON C.Id = H.CityId AND C.Id = A.CityId
GROUP BY AT.AccountId, A.Email, C.[Name]
ORDER BY COUNT(AT.AccountId) DESC, AT.AccountId

--10
SELECT * FROM Hotels 
SELECT * FROM Cities
SELECT * FROM Accounts
SELECT * FROM Trips
SELECT * FROM AccountsTrips

SELECT * FROM AccountsTrips AT
JOIN Trips T ON AT.TripId = T.Id
JOIN Rooms R ON R.Id = T.RoomId
JOIN Hotels H ON H.Id = R.HotelId
JOIN Cities C ON C.Id = H.CityId
JOIN Accounts A ON A.Id = AT.AccountId