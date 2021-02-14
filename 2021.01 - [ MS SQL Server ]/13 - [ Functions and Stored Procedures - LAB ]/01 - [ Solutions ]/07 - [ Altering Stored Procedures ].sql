ALTER PROC usp_SelectEmployeesBySeniority
AS
BEGIN

	SELECT 
		FirstName, 
		LastName, 
		HireDate, 
	    DATEDIFF(Year, HireDate, GETDATE()) as Years
		FROM Employees
		WHERE DATEDIFF(Year, HireDate, GETDATE()) > 20
		ORDER BY HireDate

END

GO

EXEC sp_depends 'usp_SelectEmployeesBySeniority'