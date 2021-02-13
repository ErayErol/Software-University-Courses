--1
CREATE TABLE Users 
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATE,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL

)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATE,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT REFERENCES Departments(Id),
)


CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(Id) NOT NULL,
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL,
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	StatusId INT REFERENCES [Status](Id) NOT NULL,
	OpenDate DATE NOT NULL,
	CloseDate DATE,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT REFERENCES Users(Id) NOT NULL,
	EmployeeId INT REFERENCES Employees(Id)
)

--2
INSERT INTO 
	Employees
	(FirstName, LastName, Birthdate, DepartmentId)
	VALUES
	('Marlo', 'O''Malley', '1958-9-21', 1),
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-14', 9),
	('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO 
	Reports
	(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
	VALUES
	(1,	1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	(6,	3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	(14, 2,	'2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4,	3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--3
UPDATE
	Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL

--4
DELETE
	FROM Reports
	WHERE StatusId = 4

--5
SELECT 
	[Description],
	FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
	FROM Reports 
	WHERE EmployeeId IS NULL 
	ORDER BY YEAR(OpenDate), MONTH(OpenDate), DAY(OpenDate), [Description]

--6
SELECT 
	R.[Description], 
	C.[Name] AS CategoryName
	FROM Reports R 
	JOIN Categories C ON C.Id = R.CategoryId 
	ORDER BY R.[Description], C.[Name]

--7
SELECT 
	TOP 5
	C.[Name] AS CategoryName,
	COUNT(R.CategoryId) AS ReportsNumber 
	FROM Reports R 
	JOIN Categories C ON C.Id = R.CategoryId 
	GROUP BY R.CategoryId, C.[Name] 
	ORDER BY ReportsNumber DESC, C.[Name]