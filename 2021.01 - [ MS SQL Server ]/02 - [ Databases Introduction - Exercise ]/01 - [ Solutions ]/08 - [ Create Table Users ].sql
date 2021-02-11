CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Eray', 'strongpas123', 'https://github.com/craigg-msft.png?size=32', '12/1/2021',0),
('Eray2', 'strongpas1234', 'https://github.com/craigg-msft.png?size=32', '1/1/2021',0),
('Eray3', 'strongpas1235', 'https://github.com/craigg-msft.png?size=32', '4/1/2021',0),
('Eray4', 'strongpas1236', 'https://github.com/craigg-msft.png?size=32', '5/1/2021',0),
('Eray5', 'strongpas1237', 'https://github.com/craigg-msft.png?size=32', '5/9/2021',0)