--CREATE DATABASE CarRental Comment because of Judge

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
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
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(50) NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear DATETIME2 NOT NULL,
	CategoryId INT CONSTRAINT FK_Cars_CategoryId FOREIGN KEY REFERENCES Categories(Id),
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
	Id INT PRIMARY KEY IDENTITY,
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
	Id INT PRIMARY KEY IDENTITY,
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
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT CONSTRAINT FK_RentalOrdersEmployeeId_EmployeeId FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT CONSTRAINT FK_RentalOrdersCustomerId_CustomerId FOREIGN KEY REFERENCES Customers(Id),
	CarId INT CONSTRAINT FK_RentalOrdersCarId_CarId FOREIGN KEY REFERENCES Cars(Id),
	TankLevel TINYINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage AS KilometrageEnd-KilometrageStart,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied TINYINT,
	TaxRate TINYINT NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RentalOrders
(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 10, 175000, 185000, '2021-01-14', '2021-02-15', 10, 10, 'Proccesing', NULL),
(2, 2, 2, 8, 195000, 215000, '2021-01-14', '2021-04-15', 10, 10, 'Proccesing', NULL),
(3, 3, 3, 5, 105000, 115000, '2021-01-14', '2021-01-21', 10, 10, 'Proccesing', NULL)