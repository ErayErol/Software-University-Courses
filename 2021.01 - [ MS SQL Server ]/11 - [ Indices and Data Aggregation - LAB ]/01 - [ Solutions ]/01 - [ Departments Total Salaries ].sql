SELECT
	d.[Name],
	MAX(e.Salary) AS TotalSalary
  FROM Employees e
  LEFT JOIN Departments d ON d.DepartmentID = e.DepartmentID
	GROUP BY d.[Name]
  ORDER BY TotalSalary DESC