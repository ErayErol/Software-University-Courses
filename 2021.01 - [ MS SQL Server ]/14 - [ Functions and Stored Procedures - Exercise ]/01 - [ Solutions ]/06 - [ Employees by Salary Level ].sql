CREATE PROC usp_EmployeesBySalaryLevel (@levelOfSalary NVARCHAR(35))
AS
  SELECT 
    FirstName AS [First Name],
	LastName AS [Last Name]
	FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary

GO

EXEC ufn_EmployeesBySalaryLevel 'High'