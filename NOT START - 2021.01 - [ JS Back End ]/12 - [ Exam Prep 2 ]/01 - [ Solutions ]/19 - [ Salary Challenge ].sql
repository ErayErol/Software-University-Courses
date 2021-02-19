WITH DepartmentAndAvgSalary AS
(
SELECT
	DepartmentID,
	AVG(Salary) AS AvgSalary
    FROM Employees
	GROUP BY DepartmentID
)

SELECT 
	TOP(10)
	e.FirstName,
	e.LastName,
	e.DepartmentID
	FROM Employees e
	JOIN DepartmentAndAvgSalary n ON e.Salary > n.AvgSalary 
	  AND e.DepartmentID = n.DepartmentID