CREATE PROC usp_GetEmployeesSalaryAboveNumber (@givenSalary DECIMAL(18,4))
AS
  SELECT 
    FirstName AS [First Name],
	LastName AS [Last Name]
	FROM Employees
WHERE Salary >= @givenSalary

EXEC usp_GetEmployeesSalaryAboveNumber 92000