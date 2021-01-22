USE DictionaryENBG

CREATE TABLE Words
(
	ID		INT PRIMARY KEY,
	[Name]	VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE WordsTranslate
(
	ID			INT IDENTITY PRIMARY KEY,
	[Translate]	NVARCHAR(200) NOT NULL,
	WordID		INT NOT NULL FOREIGN KEY REFERENCES Words (ID)
)

CREATE TABLE Phrases
(
	ID		INT PRIMARY KEY,
	[Name]	VARCHAR(200) NOT NULL,
	WordID	INT NOT NULL FOREIGN KEY REFERENCES Words (ID)
)

CREATE TABLE PhrasesTranslate
(
	ID			INT IDENTITY PRIMARY KEY,
	[Translate] NVARCHAR(300) NOT NULL,
	PhraseID	INT NOT NULL FOREIGN KEY REFERENCES Phrases (ID)
)

CREATE TABLE Sentances
(
	ID		INT PRIMARY KEY,
	[Name]	VARCHAR(300) NOT NULL,
	WordID	INT NOT NULL FOREIGN KEY REFERENCES Words (ID)
)

CREATE TABLE SentancesTranslate
(
	ID			INT IDENTITY PRIMARY KEY,
	[Translate] NVARCHAR(300) NOT NULL,
	SentanceID	INT NOT NULL FOREIGN KEY REFERENCES Sentances (ID)
)

INSERT INTO Words
(ID ,[Name])
VALUES
(1, 'Order'),
(2, 'However'),
(3, 'Addition')

INSERT INTO WordsTranslate
([Translate], WordID)
VALUES
('Поръчка', 1),
('Ред', 1),
('Заповед', 1),
('Обаче', 2),
('Въпреки това', 2),
('Допълнение', 3)

INSERT INTO Phrases
(ID, [Name], WordID)
VALUES
(1, 'In order to [...]', 1),
(2, 'However you are free to [...]', 2),
(3, 'In addition to [...]', 3),
(4, 'Аddition and subtraction', 3)

INSERT INTO PhrasesTranslate
([Translate], PhraseID)
VALUES
('За да', 1),
('Oбаче сте свободни', 2),
('В допълнение към', 3),
('Събиране и изваждане', 3)

INSERT INTO Sentances
(ID, [Name], WordID)
VALUES
(1, 'You have to [...] in order to [...]', 1),
(2, 'However you are free to add more methods', 2),
(3, 'This method should in addition increase the size of the structure', 3)

INSERT INTO SentancesTranslate
([Translate], SentanceID)
VALUES
('Трябва да [...], за да [...]', 1),
('Но, можете да добавите още методи', 2),
('Този метод трябва допълнително да увеличи размера на структурата', 3)

SELECT w.[Name], wt.[Translate], p.[Name], pt.[Translate], s.[Name], st.[Translate]
FROM Words w
INNER JOIN WordsTranslate wt ON wt.WordID = w.ID
INNER JOIN Phrases p ON p.WordID = w.ID
INNER JOIN PhrasesTranslate pt ON pt.PhraseID = p.ID
INNER JOIN Sentances s ON s.WordID = w.ID
INNER JOIN SentancesTranslate st ON st.SentanceID = s.ID
WHERE w.[Name] = 'Addition'

--DROP TABLE Phrases
--DROP TABLE PhrasesTranslate
--DROP TABLE Sentances
--DROP TABLE SentancesTranslate
--DROP TABLE Words
--DROP TABLE WordsTranslate
