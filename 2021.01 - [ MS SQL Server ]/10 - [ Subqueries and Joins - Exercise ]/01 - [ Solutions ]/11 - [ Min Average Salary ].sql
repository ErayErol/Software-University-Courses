WITH 
	GroupedDepartmentsByAvgSalary 
	(DepartmentID, AverageSalary) AS
	(
	SELECT 
	DepartmentID, 
	AVG(Salary) AS AverageSalary
	FROM Employees
	GROUP BY DepartmentID
	)

SELECT 
	MIN(AverageSalary) AS MinAverageSalary
	FROM GroupedDepartmentsByAvgSalary