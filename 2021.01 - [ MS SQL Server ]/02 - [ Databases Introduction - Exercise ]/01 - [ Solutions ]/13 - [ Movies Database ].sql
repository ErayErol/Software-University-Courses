CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO 
	Directors
	(DirectorName)
	VALUES
	('Ridley Scott'),
	('Tom Shadyac'),
	('Chris Columbus'),
	('Peter Jackson'),
	('David Fincher')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO 
	Genres
	(GenreName)
	VALUES
	('Action'),
	('Fantasy'),
	('Adventure'),
	('Drama'),
	('Comedy')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO 
	Categories
	(CategoryName)
	VALUES
	('Film/HD'),
	('Film/SD'),
	('Film/BG'),
	('Video/BG'),
	('Film/3D')

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(5,2),
	Notes NVARCHAR(MAX) NOT NULL
)

ALTER TABLE Movies 
ADD CONSTRAINT FK_MovieDirectorId_DirectorId
FOREIGN KEY (DirectorId) REFERENCES Directors (Id)

ALTER TABLE Movies 
ADD CONSTRAINT FK_MovieGenreId_GenreId
FOREIGN KEY (GenreId) REFERENCES Genres (Id)

ALTER TABLE Movies 
ADD CONSTRAINT FK_MovieCategoryId_CategoryId
FOREIGN KEY (CategoryId) REFERENCES Categories (Id)

INSERT INTO 
	Movies
	(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
	VALUES
	('Gladiator', 1, '2000-05-01', 155, 1, 1, 8.5, 'Gladiator is a 2000 epic historical drama.'),
	('Liar Liar', 2, '1997-03-18', 86, 5, 1, 6.9, 'Liar Liar is a 1997 American fantasy comedy film.'),
	('Harry Potter and the Philosopher''s Stone', 3, '2001-11-04', 152, 2, 1, 7.6, 'Harry Potter and the Philosopher''s Stone is a 2001 fantasy film.'),
	('Fight Club', 5, '1999-10-15', 139, 4, 1, 8.8, 'Fight Club is a 1999 American film.'),
	('The Lord of the Rings: The Fellowship of the Ring', 4, '2001-12-10', 178, 3, 1, 8.8, 'The Lord of the Rings: The Fellowship of the Ring is a 2001 epic fantasy adventure film.')