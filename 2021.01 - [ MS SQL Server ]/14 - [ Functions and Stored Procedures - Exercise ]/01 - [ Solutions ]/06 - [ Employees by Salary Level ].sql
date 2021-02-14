CREATE PROC usp_EmployeesBySalaryLevel (@levelOfSalary NVARCHAR(35))
AS
BEGIN

	SELECT 
		FirstName AS [First Name],
		LastName AS [Last Name]
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary

END

--GO

--EXEC ufn_EmployeesBySalaryLevel 'High'