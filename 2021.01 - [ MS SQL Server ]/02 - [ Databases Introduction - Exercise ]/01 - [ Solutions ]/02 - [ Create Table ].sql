CREATE TABLE Minions (
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,[Name] NVARCHAR(50)
	,Age TINYINT
	)

CREATE TABLE Towns (
	Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
	,[Name] NVARCHAR(50)
	)