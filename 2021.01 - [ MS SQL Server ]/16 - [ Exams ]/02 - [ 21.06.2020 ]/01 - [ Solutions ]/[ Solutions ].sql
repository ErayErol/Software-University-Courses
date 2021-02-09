-- 1
CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL (15,2) 
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL (15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	CHECK (BookDate < ArrivalDate),
	ReturnDate DATE NOT NULL,
	CHECK (ArrivalDate < ReturnDate),
	CancelDate DATE
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
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
(101, '2015-04-12',	'2015-04-24', '2015-04-20',	'2015-02-02'),
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
SELECT 
	C.[Name], COUNT(*) AS Hotels 
FROM 
	Hotels H 
JOIN 
	Cities C ON C.Id = H.CityId 
GROUP BY 
	C.[Name] 
ORDER BY 
	Hotels DESC, C.[Name]

--7
SELECT 
	AT.AccountId, 
	A.FirstName + ' ' + A.LastName AS [FullName], 
	MAX(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS LongestTrip, 
	MIN(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate)) AS ShortestTrip
FROM 
	AccountsTrips AT
LEFT JOIN Accounts A ON A.Id = AT.AccountId
LEFT JOIN Trips T ON T.Id = AT.TripId
WHERE 
	A.MiddleName IS NULL AND T.CancelDate IS NULL
GROUP BY 
	AT.AccountId, A.FirstName, A.LastName
ORDER BY 
	LongestTrip desc, ShortestTrip

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
SELECT 
	AT.AccountId, A.Email, C.[Name], COUNT(AT.AccountId) AS Trips
FROM 
	AccountsTrips AT
JOIN Accounts A ON A.Id = AT.AccountId
JOIN Trips T ON T.Id = AT.TripId
JOIN Rooms R ON R.Id = T.RoomId
JOIN Hotels H ON H.Id = R.HotelId
JOIN Cities C ON C.Id = H.CityId AND C.Id = A.CityId
GROUP BY 
	AT.AccountId, A.Email, C.[Name]
ORDER BY 
	COUNT(AT.AccountId) DESC, AT.AccountId

--10
SELECT 
	T.Id,
	A.FirstName + ' ' + ISNULL(A.MiddleName + ' ', '') + A.LastName AS [Full Name], 
	C.[Name] AS [From],
	C2.[Name] AS [To],
	IIF(T.CancelDate IS NULL, CAST(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate) AS VARCHAR(MAX)) + ' days', 'Canceled') AS [Duration]
FROM 
	AccountsTrips AT
JOIN Accounts A ON A.Id = AT.AccountId
JOIN Cities C ON C.Id = A.CityId
JOIN Trips T ON T.Id = AT.TripId
JOIN Rooms R ON R.Id = T.RoomId
JOIN Hotels H ON H.Id = R.HotelId
JOIN Cities C2 ON C2.Id = H.CityId
ORDER BY 
	[Full Name], T.Id

--11
CREATE FUNCTION udf_GetAvailableRoom (@hotelId INT, @date DATE, @people INT)
RETURNS NVARCHAR(400)
AS
BEGIN
	
	DECLARE @roomId INT = (SELECT TOP 1 R.Id FROM Rooms R JOIN Hotels H ON H.Id = R.HotelId WHERE H.Id = @hotelId ORDER BY R.Price DESC)

	DECLARE @roomPrice DECIMAL(15, 2) = (SELECT Price FROM Rooms WHERE Id = @roomId)
	
	DECLARE @hotelBaseRate DECIMAL(15, 2) = (SELECT BaseRate FROM Hotels WHERE Id = @hotelId)

	DECLARE @totalPrice DECIMAL (15, 2) = (@hotelBaseRate + @roomPrice) * @people

	DECLARE @tripArrivalDate DATE = 
								(SELECT TOP 1 T.ArrivalDate	
								FROM Rooms R 
								JOIN Hotels H ON H.Id = R.HotelId 
								JOIN Trips T ON T.RoomId = R.Id 
								WHERE H.Id = @hotelId AND T.CancelDate IS NULL AND T.RoomId = @roomId)

	DECLARE @tripReturnDate DATE = 
								(SELECT TOP 1 T.ReturnDate 
								FROM Rooms R 
								JOIN Hotels H ON H.Id = R.HotelId 
								JOIN Trips T ON T.RoomId = R.Id 
								WHERE H.Id = @hotelId AND T.CancelDate IS NULL AND T.RoomId = @roomId)

	DECLARE @result NVARCHAR(400) = 'No rooms available'

	IF (@date BETWEEN @tripArrivalDate AND @tripReturnDate)
		RETURN @result

	IF NOT EXISTS 
	(
		SELECT R.Id 
		FROM Hotels H 
		JOIN Rooms R ON R.HotelId = H.Id 
		WHERE H.Id = @hotelId AND @roomId = ANY 
											  (
											    SELECT R.Id 
											    FROM Hotels H JOIN Rooms R ON R.HotelId = H.Id 
											    WHERE H.Id = @hotelId AND R.Id = @roomId
											  )
	)
		RETURN @result

	DECLARE @roomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @roomId)

	IF (@people > @roomBeds)
		RETURN @result

	DECLARE @roomType NVARCHAR(100) = (SELECT [Type] FROM Rooms WHERE Id = @roomId)

	SET @result = 
		'Room ' + CAST(@roomId AS NVARCHAR(50)) + ': ' + CAST(@roomType AS NVARCHAR(50)) + ' (' + CAST(@roomBeds AS NVARCHAR(50)) + ' beds) - $' + CAST(@totalPrice AS NVARCHAR(50))
			RETURN @result
END

--12
CREATE PROC usp_SwitchRoom (@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @tripHotel INT = (SELECT R.HotelId FROM Trips T JOIN Rooms R ON R.Id = T.RoomId WHERE T.Id = @TripId)
	
	DECLARE @roomHotel INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)

	IF (@tripHotel <> @roomHotel)
		THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @bedsNeeded INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)
	
	DECLARE @beds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)
	
	IF (@bedsNeeded > @beds)
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE Trips SET RoomId = @TargetRoomId WHERE Id = @TripId
END