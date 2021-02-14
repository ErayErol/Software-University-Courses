CREATE PROC dbo.usp_SelectEmployeesBySeniority 
AS
BEGIN

	SELECT * 
		FROM Employees
		WHERE DATEDIFF(Year, HireDate, GETDATE()) > 20

END

--GO

--EXEC usp_SelectEmployeesBySeniority