--1
CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age TINYINT CHECK(Age > 0),
	[Address] NVARCHAR(50),
	Phone NCHAR(10),	
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT REFERENCES Students(Id) NOT NULL,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL (15, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentId INT REFERENCES Students(Id) NOT NULL,
	ExamId INT REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL (15, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL

	PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NCHAR(10),	
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers
(
	StudentId INT REFERENCES Students(Id) NOT NULL,
	TeacherId INT REFERENCES Teachers(Id) NOT NULL,

	PRIMARY KEY (StudentId, TeacherId)
)

--2
INSERT INTO 
	Teachers
	(FirstName, LastName, [Address], Phone, SubjectId)
	VALUES
	('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
	('Gerrard', 'Lowin', '370 Talisman Plaza', 3324874824, 2),
	('Merrile', 'Lambdin', '81 Dahle Plaza', 4373065154, 5),
	('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4)


INSERT INTO 
	Subjects
	([Name], Lessons)
	VALUES
	('Geometry', 12),
	('Health', 10),
	('Drama', 7),
	('Sports', 9)

--3
UPDATE
	StudentsSubjects
	SET Grade = 6.00
	WHERE (SubjectId = 1 OR SubjectId = 2) AND Grade >= 5.50

--4
DELETE 
	ST
	FROM StudentsTeachers ST 
	JOIN Teachers T ON T.Id = ST.TeacherId 
	WHERE T.Phone LIKE '%72%'

DELETE 
	Teachers 
	WHERE Phone LIKE '%72%'

--5
SELECT 
	FirstName, 
	LastName, 
	Age 
	FROM Students 
	WHERE Age >= 12 
	ORDER BY FirstName, LastName

--6
SELECT 
	S.FirstName, 
	S.LastName, 
	COUNT(TeacherId) AS TeachersCount
	FROM StudentsTeachers ST 
	JOIN Students S ON S.Id = ST.StudentId 
	GROUP BY StudentId, S.FirstName, S.LastName
	ORDER BY S.LastName

--7
SELECT 
	CONCAT(S.FirstName, ' ', S.LastName) AS [Full Name]
	FROM Students S 
	LEFT JOIN StudentsExams SE ON SE.StudentId = S.Id 
	WHERE SE.StudentId IS NULL
	ORDER BY [Full Name]

--8
SELECT
	TOP 10
	S.FirstName, 
	S.LastName,
	CAST(AVG(SE.Grade) AS DECIMAL (3, 2)) AS Grade
	FROM StudentsExams SE
	JOIN Students S ON S.Id = SE.StudentId
	GROUP BY SE.StudentId, S.FirstName, S.LastName
	ORDER BY CAST(AVG(SE.Grade) AS DECIMAL (3, 2)) DESC, S.FirstName, S.LastName

--9
SELECT 
	CONCAT(S.FirstName, ' ', S.MiddleName + ' ', S.LastName) AS [Full Name]
	FROM StudentsSubjects SS 
	RIGHT JOIN Students S ON S.Id = SS.StudentId 
	WHERE SS.Id IS NULL
	ORDER BY [Full Name]

--10
SELECT 
	S.[Name],
	AVG(SS.Grade) AS AverageGrade
	FROM StudentsSubjects SS
	JOIN Subjects S ON S.Id = SS.SubjectId
	GROUP BY SS.SubjectId, S.[Name]
	ORDER BY SS.SubjectId

--11
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT , @grade DECIMAL (3, 2))
RETURNS NVARCHAR(MAX)
AS
BEGIN

	DECLARE @error NVARCHAR(MAX)

	IF NOT EXISTS((SELECT * FROM StudentsExams WHERE StudentId = @studentId))
	BEGIN
		SET @error = 'The student with provided id does not exist in the school!'
		RETURN @error
	END

	IF (@grade > 6.00)
	BEGIN
		SET @error = 'Grade cannot be above 6.00!'
		RETURN @error
	END

	DECLARE @studentName NVARCHAR(MAX) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	DECLARE @count INT = 
		(
		SELECT 
		SUM(K.Count) 
		FROM (
		SELECT 
		COUNT(StudentId) AS [Count]
		FROM StudentsExams 
		WHERE StudentId = @studentId AND Grade != @grade AND 
		  Grade BETWEEN @grade - 0.50 AND @grade + 0.50 
		GROUP BY StudentId, ExamId, Grade
		) AS K
		)

	DECLARE @output NVARCHAR(MAX) = 
				'You have to update ' + 
				CAST(@count AS NVARCHAR(MAX)) + 
				' grades for the student ' + 
				@studentName

	RETURN @output

END

--12
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	
	IF NOT EXISTS (SELECT * FROM Students WHERE Id = @StudentId)
	BEGIN
		THROW 50001, 'This school has no student with the provided id!', 1
	END

	DELETE 
		ST
		FROM StudentsTeachers ST 
		WHERE ST.StudentId = @StudentId

	DELETE 
		SE
		FROM StudentsExams SE
		WHERE SE.StudentId = @StudentId

	DELETE 
		SB
		FROM StudentsSubjects SB
		WHERE SB.StudentId = @StudentId

	DELETE 
		Students 
		WHERE Id = @StudentId
	
END