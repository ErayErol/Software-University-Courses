--CREATE DATABASE CarRental Comment because of Judge

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(7,2) NOT NULL,
	WeeklyRate DECIMAL(7,2) NOT NULL,
	MonthlyRate DECIMAL(7,2) NOT NULL,
	WeekendRate DECIMAL(7,2) NOT NULL,
)

INSERT INTO Categories
(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Sport/Coupe', 100, 600, 2500, 400),
('Cabrio', 50, 300, 1250, 200),
('Kombi', 10, 60, 250, 40)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber NVARCHAR(50) NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear DATETIME2 NOT NULL,
	CategoryId INT NOT NULL,
	Doors TINYINT,
	Picture IMAGE,
	Condition CHAR(1) NOT NULL,
	Available BIT NOT NULL,
)

INSERT INTO Cars
(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
('X8688KA', 'BMW', 'E92', '2007-12-01', 1, 2, NULL, 'S', 1),
('X7177BT', 'Chevrolet', 'Camaro', '1998-05-15', 2, 2, NULL, 'S', 0),
('X4128KK', 'Opel', 'Astra', '2001-02-01', 3, 4, NULL, 'S', 1)

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
	DriverLicenceNumber BIGINT NOT NULL,
	FullName  NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode INT,
	Notes NVARCHAR(MAX),
)

INSERT INTO Customers
(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES
(1234567890, 'Myumyun Erol', 'Prohlada', 'Haskovo', 6300, NULL),
(9876543210, 'Erduan Yilmaz', 'Pod Sportna sreshta', 'Haskovo', 6300, NULL),
(5678901234, 'Osi Mehmed', 'StockholmUniversity', 'Stockholm', 11122, NULL)


CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel TINYINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays SMALLINT NOT NULL,
	RateApplied TINYINT,
	TaxRate TINYINT NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

ALTER TABLE RentalOrders 
ADD CONSTRAINT FK_RentalOrdersEmployeeId_EmployeeId
FOREIGN KEY (EmployeeId) REFERENCES Employees (Id)

ALTER TABLE RentalOrders 
ADD CONSTRAINT FK_RentalOrdersCustomerId_CustomerId
FOREIGN KEY (CustomerId) REFERENCES Customers (Id)

ALTER TABLE RentalOrders 
ADD CONSTRAINT FK_RentalOrdersCarId_CarId
FOREIGN KEY (CarId) REFERENCES Cars (Id)

INSERT INTO RentalOrders
(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 10, 175000, 185000, 10000, '2021-01-14', '2021-02-15', 30, 10, 10, 'Proccesing', NULL),
(2, 2, 2, 8, 195000, 215000, 20000, '2021-01-14', '2021-04-15', 90, 10, 10, 'Proccesing', NULL),
(3, 3, 3, 5, 105000, 115000, 10000, '2021-01-14', '2021-01-21', 7, 10, 10, 'Proccesing', NULL)