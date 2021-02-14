CREATE TABLE Cities
(
	CityID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT REFERENCES Cities (CityID) NOT NULL 
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes (ItemTypeID) NOT NULL 
)


CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY,
	CustomerID INT REFERENCES Customers (CustomerID) NOT NULL 
)

CREATE TABLE OrderItems
(
	OrderID INT REFERENCES Orders(OrderID),
	ItemID INT REFERENCES Items(ItemID)
	
	PRIMARY KEY(OrderID, ItemID)
)