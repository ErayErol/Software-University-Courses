SELECT
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS ManagerName
	FROM Employees AS e
	LEFT JOIN Employees AS m ON m.EmployeeID = e.ManagerID
	WHERE e.ManagerID = 3 OR e.ManagerID = 7
	ORDER BY e.EmployeeID