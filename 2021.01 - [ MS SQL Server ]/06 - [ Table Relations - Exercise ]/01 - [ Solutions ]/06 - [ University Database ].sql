CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	StudentNumber INT,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT NOT NULL FOREIGN KEY REFERENCES Majors (MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY,
	PaymentDate DATETIME,
	StudentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students (StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY,
	SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Subjects (SubjectID),
	SubjectID INT FOREIGN KEY REFERENCES Students (StudentID),
		CONSTRAINT PK_Agenda
		PRIMARY KEY(StudentID, SubjectID),
)