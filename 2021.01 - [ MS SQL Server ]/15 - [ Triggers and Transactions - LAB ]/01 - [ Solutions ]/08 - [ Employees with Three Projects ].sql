USE SoftUni
GO
ALTER PROC usp_SelectEmployeesBySeniority
AS
  SELECT FirstName, LastName, HireDate, 
    DATEDIFF(Year, HireDate, GETDATE()) as Years
  FROM Employees
  WHERE DATEDIFF(Year, HireDate, GETDATE()) > 20
  ORDER BY HireDate
GO

EXEC sp_depends 'usp_SelectEmployeesBySeniority'