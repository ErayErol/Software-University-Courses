CREATE PROC usp_GetTownsStartingWith (@startLetters NVARCHAR(25))
AS
SELECT 
	[Name] 
  FROM Towns
WHERE [Name] LIKE @startLetters + '%';

EXEC usp_GetTownsStartingWith "b"