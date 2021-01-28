SELECT TOP(3)
	e.EmployeeID, e.FirstName
  FROM Employees e 
	LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
  WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID