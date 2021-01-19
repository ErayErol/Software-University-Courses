CREATE TABLE Passports
(
	PassportID		INT IDENTITY(101, 1) PRIMARY KEY,
	PassportNumber	NVARCHAR(8)
)

CREATE TABLE Persons
(
    PersonID	INT	IDENTITY PRIMARY KEY,
    FirstName	NVARCHAR(25) NOT NULL,
    Salary		DECIMAL(7, 2) NOT NULL,
	PassportID	INT UNIQUE,
		CONSTRAINT	FK_PersonsPassportID_PassportsPassportID
		FOREIGN KEY	(PassportID)
		REFERENCES	Passports (PassportID)
)

INSERT INTO Passports
(PassportNumber)
VALUES					
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons	
(FirstName, Salary, PassportID)
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)