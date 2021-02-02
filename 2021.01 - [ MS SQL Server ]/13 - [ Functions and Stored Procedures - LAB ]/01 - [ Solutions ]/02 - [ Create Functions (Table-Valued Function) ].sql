CREATE FUNCTION udf_AverageSalaryByDepartment()
RETURNS TABLE AS
RETURN 
(
	SELECT d.[Name] AS Department, AVG(e.Salary) AS AverageSalary 
	FROM Departments AS d 
	JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
	GROUP BY d.DepartmentID, d.[Name]
)

SELECT * FROM dbo.udf_AverageSalaryByDepartment()