CREATE PROC usp_GetHoldersFullName
AS
BEGIN
  
	SELECT 
		FirstName + ' ' + LastName AS [Full Name]
		FROM AccountHolders

END

--GO

--EXEC usp_GetHoldersFullName