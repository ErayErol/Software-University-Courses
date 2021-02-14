CREATE PROC usp_GetTownsStartingWith (@startLetters NVARCHAR(25))
AS
BEGIN
	
	SELECT 
		[Name] 
		FROM Towns
		WHERE [Name] LIKE @startLetters + '%';

END

--GO

--EXEC usp_GetTownsStartingWith "b"