CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID)

	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO 
	Students
	([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO 
	Exams
	([Name])
	VALUES
	('SpringMVC'),
	('Oracle '),
	('Oracle 11g')

INSERT INTO 
	StudentsExams
	(StudentID, ExamID)
	VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)