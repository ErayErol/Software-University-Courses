CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(35)
AS
BEGIN
    DECLARE @LevelOfTheSalary NVARCHAR(35);
    IF(@salary < 30000)
        SET @LevelOfTheSalary = 'Low'
	ELSE IF (@salary <= 50000 )
        SET @LevelOfTheSalary = 'Average'
	ELSE IF (@salary > 50000)
		SET @LevelOfTheSalary = 'High'
    RETURN @LevelOfTheSalary;
END

GO

SELECT 
  Salary, 
  (SELECT dbo.ufn_GetSalaryLevel(Salary)) AS [SalaryLevel]
FROM Employees

SELECT dbo.ufn_GetSalaryLevel(NULL)