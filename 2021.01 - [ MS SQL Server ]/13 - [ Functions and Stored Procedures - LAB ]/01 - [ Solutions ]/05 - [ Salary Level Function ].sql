CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS NVARCHAR(35)
AS
BEGIN
    DECLARE @LevelOfTheSalary NVARCHAR(35);
	IF(@Salary <= 0)
        SET @LevelOfTheSalary = 'Cannot be zero or negative'
    ELSE IF(@Salary < 30000)
        SET @LevelOfTheSalary = 'Low'
	ELSE IF (@Salary <= 50000 )
        SET @LevelOfTheSalary = 'Average'
	ELSE IF (@Salary > 50000)
		SET @LevelOfTheSalary = 'High'
	ELSE 
		SET @LevelOfTheSalary = 'Unknown'
    RETURN @LevelOfTheSalary;
END

GO

SELECT 
  FirstName, 
  LastName, 
  Salary, 
  (SELECT dbo.ufn_GetSalaryLevel(Salary)) AS [SalaryLevel]
FROM Employees

SELECT dbo.ufn_GetSalaryLevel(NULL)