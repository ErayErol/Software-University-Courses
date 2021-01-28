SELECT 
	e.EmployeeID,
	e.FirstName,
	CASE
      WHEN p.StartDate >= '2005-01-01' AND p.StartDate <= '2005-12-31' THEN NULL
      ELSE p.[Name]
	END AS [Project Name]
  FROM Employees e 
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID= ep.ProjectID
  WHERE e.EmployeeID = 24
ORDER BY e.EmployeeID