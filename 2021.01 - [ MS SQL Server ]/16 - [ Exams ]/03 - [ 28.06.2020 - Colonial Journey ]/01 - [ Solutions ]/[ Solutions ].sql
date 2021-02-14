--1
CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) 
	CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT REFERENCES Spaceships(Id) NOT NULL,
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8) 
	CHECK(JobDuringJourney IN 
	('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT REFERENCES Journeys(Id) NOT NULL,
)

--2
INSERT INTO 
	Planets ([Name])
	VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO 
	Spaceships ([Name],Manufacturer, LightSpeedRate)
	VALUES
	('Golf', 'VW', 3),
	('WakaWaka', 'Wakanda', 4),
	('Falcon9', 'SpaceX', 1),
	('Bed',	'Vidolov', 6)

--3
UPDATE 
	Spaceships 
	SET LightSpeedRate +=1 
	WHERE Id BETWEEN 8 AND 12

--4
DELETE 
	FROM TravelCards 
	WHERE JourneyId IN (1,2,3)

DELETE 
	FROM Journeys 
	WHERE Id IN (1,2,3)

--5
SELECT 
	Id, 
	FORMAT(JourneyStart, 'dd-MM-yyyy') AS JourneyStart,
	FORMAT(JourneyEnd, 'dd-MM-yyyy') AS JourneyEnd
	FROM Journeys 
	WHERE Purpose = 'Military'
	ORDER BY FORMAT(JourneyStart, 'dd-MM-yyyy')

--6
SELECT
	C.ID,
	CONCAT(FirstName, ' ', LastName) AS [FullName]
	FROM Colonists C
	JOIN TravelCards TC ON TC.ColonistId = C.Id
	WHERE TC.JobDuringJourney = 'Pilot'
	ORDER BY c.Id

--7
SELECT 
	COUNT(*) AS [count]
	FROM Colonists C
	JOIN TravelCards TC ON TC.ColonistId = C.Id
	JOIN Journeys J ON J.Id = TC.JourneyId
	WHERE J.Purpose = 'Technical'

--8
SELECT 
	SS.[Name],
	SS.Manufacturer
	FROM Spaceships SS
	JOIN Journeys J ON J.SpaceshipId = SS.Id
	JOIN TravelCards TC ON TC.JourneyId = J.Id AND TC.JobDuringJourney = 'Pilot'
	JOIN Colonists C ON C.Id = TC.ColonistId AND DATEDIFF(YEAR, C.BirthDate, '01/01/2019') < 30
	ORDER BY SS.[Name]

--9
SELECT 
 	P.[Name],
	COUNT(*) AS JourneysCount
	FROM Planets P
	JOIN Spaceports SP ON SP.PlanetId = P.Id
	JOIN Journeys J ON J.DestinationSpaceportId = SP.Id
	GROUP BY P.[Name]
	ORDER BY JourneysCount DESC, P.[Name]

--10
SELECT 
	* FROM 
	(
	SELECT
	TC.JobDuringJourney,
	C.FirstName + ' ' + C.LastName AS [FullName],
	DENSE_RANK() OVER(PARTITION BY JobDuringJourney ORDER BY C.BirthDate) AS JobRank
	FROM Colonists C JOIN TravelCards TC ON TC.ColonistId = C.Id
	) AS K
	WHERE K.JobRank = 2

--11
CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN

	DECLARE 
		@Result INT = (SELECT 
						COUNT(*)
						FROM Planets P
						JOIN Spaceports SP ON SP.PlanetId = P.Id
						JOIN Journeys J ON J.DestinationSpaceportId = SP.Id
						JOIN TravelCards TC ON TC.JourneyId = J.Id
						JOIN Colonists C ON C.Id = TC.ColonistId
						WHERE P.[Name] = @PlanetName
					  );

	RETURN @Result;

END

--12
CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Journeys WHERE Id = @JourneyId)
		THROW 50001, 'The journey does not exist!', 1
	
	IF ((SELECT Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose)
		THROW 50002, 'You cannot change the purpose!', 1
	
	UPDATE 
		Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId

END