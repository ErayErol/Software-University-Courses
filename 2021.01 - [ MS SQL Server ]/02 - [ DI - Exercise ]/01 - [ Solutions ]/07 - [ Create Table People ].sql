CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(2),
	Height DECIMAL(5,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2(7) NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People
([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES 
('Eray', NULL, 179, 75, 'm', '1995-09-30 14:00:00', 'I''m Full Stack Dev.'),
('Djani', NULL, 160, 49, 'f', '1995-09-08 11:00:00', 'I''m Designer.'),
('Meri', NULL, 160, 70, 'f', '1968-12-31 10:00:00', 'I''m Business Lady.'),
('Erol', NULL, 177, 90, 'm', '1967-11-19 14:00:00', 'I''m Car Mechanic.'),
('Bayrie', NULL, 170, 52, 'm', '1990-09-13 12:00:00', 'I''m HouseWife.')