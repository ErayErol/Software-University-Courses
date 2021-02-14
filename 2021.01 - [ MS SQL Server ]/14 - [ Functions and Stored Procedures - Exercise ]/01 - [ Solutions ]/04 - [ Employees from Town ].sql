CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(50))
AS
BEGIN

	SELECT 
		e.FirstName AS [First Name],
		e.LastName AS [Last Name]
		FROM Employees e
		JOIN Addresses a ON a.AddressID = e.AddressID
		JOIN Towns t ON t.TownID = a.TownID
		WHERE t.[Name] = @townName

END

--GO

--EXEC usp_GetEmployeesFromTown 'Sofia'