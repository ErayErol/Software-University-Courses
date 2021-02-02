CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS NVARCHAR(10)
AS
BEGIN
    DECLARE @LevelOfTheSalary NVARCHAR(25);
    IF(@Salary < 30000)
	BEGIN
        SET @LevelOfTheSalary = 'Low'
	END
	ELSE IF (@Salary >= 30000 AND @Salary <= 50000 )
	BEGIN
        SET @LevelOfTheSalary = 'Average'
	END
	ELSE IF (@Salary > 50000)
	BEGIN
		SET @LevelOfTheSalary = 'High'
	END
    RETURN @LevelOfTheSalary;
END

SELECT 
  FirstName, 
  LastName, 
  Salary, 
  (SELECT dbo.ufn_GetSalaryLevel(Salary))AS [SalaryLevel]
FROM Employees