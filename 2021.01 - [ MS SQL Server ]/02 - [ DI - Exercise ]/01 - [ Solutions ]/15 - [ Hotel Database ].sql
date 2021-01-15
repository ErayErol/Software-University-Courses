-- CREATE DATABASE Hotel Comment because of Judge
--DROP DATABASE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(90) NOT NULL,
	LastName NVARCHAR(90) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
(FirstName, LastName, Title, Notes)
VALUES
('Eray', 'Erol', NULL, NULL),
('Djani', 'Eliaydin', NULL, NULL),
('Bayrie', 'Erol', NULL, NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName NVARCHAR(90) NOT NULL,
	LastName NVARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName NVARCHAR(90)NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers
(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
(1, 'Meri', 'Djemal', 0886914993, 'Meri', 0886914993, NULL),
(2, 'Erol', 'Djemal', 0888611124, 'Erol', 0888611124, NULL),
(3, 'Eliaydin', 'Uzeir', 0888998811, 'Elio', 0888998811, NULL)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(10) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
(RoomStatus, Notes)
VALUES
('Cleaning', NULL),
('Vacant', NULL),
('Dirty', NULL)

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes
(RoomType, Notes)
VALUES
('Single', NULL),
('Double', NULL),
('Suite', NULL)

CREATE TABLE BedTypes
(
	BedType NVARCHAR(30) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes
(BedType, Notes)
VALUES
('Twin', NULL),
('Twin Double', NULL),
('Hollywood Twin', NULL)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(30) NOT NULL CONSTRAINT FK_RoomsRoomType_RoomType FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(30) NOT NULL CONSTRAINT FK_RoomsBedType_BedType FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(7,2) NOT NULL,
	RoomStatus NVARCHAR(10) NOT NULL CONSTRAINT FK_RoomsRoomStatus_RoomStatus FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms
(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
(1, 'Single', 'Twin', 70, 'Dirty', NULL),
(2, 'Double', 'Twin Double', 120, 'Cleaning', NULL),
(3, 'Suite', 'Hollywood Twin', 350, 'Vacant', NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL CONSTRAINT FK_PaymentsEmployeeId_EmployeeId FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME2 NOT NULL,
	AccountNumber INT NOT NULL CONSTRAINT FK_PaymentsAccountNumber_CustomerAccountNumber FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(7,2) NOT NULL,
	TaxRate DECIMAL(7,2) NOT NULL,
	TaxAmount DECIMAL(7,2) NOT NULL,
	PaymentTotal DECIMAL(7,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments
(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
()


CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL CONSTRAINT FK_OccupanciesEmployeeId_EmployeeId FOREIGN KEY REFERENCES Employees(Id),
	DateOccupancied	 DATETIME2 NOT NULL,
	AccountNumber INT NOT NULL CONSTRAINT FK_OccupanciesAccountNumber_CustomerAccountNumber FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(7,2),
	PhoneCharge DECIMAL(7,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies
(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
()