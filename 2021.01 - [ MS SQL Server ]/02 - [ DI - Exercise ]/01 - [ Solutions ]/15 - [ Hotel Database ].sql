-- CREATE DATABASE Hotel Comment because of Judge

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX),
)

INSERT INTO Employees
(FirstName, LastName, Title, Notes)
VALUES
('Eray', 'Erol', NULL, NULL),
('Djani', 'Eliaydin', NULL, NULL),
('Bayrie', 'Erol', NULL, NULL)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AccountNumber INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber BIGINT NOT NULL,
	EmergencyName NVARCHAR(50)NOT NULL,
	EmergencyNumber BIGINT NOT NULL,
	Notes NVARCHAR(MAX),
)

INSERT INTO Customers
(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
(1, 'Mergyul', 'Shefket', 0886914993, 'Meri', ),