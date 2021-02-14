SELECT 
	TOP(50)
	E.EmployeeID,
	CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName,
	CONCAT(M.FirstName, ' ', M.LastName) AS ManagerName,
	D.[Name] AS DepartmentName
	FROM Employees AS E
	LEFT JOIN Employees AS M ON M.EmployeeID = E.ManagerID
	LEFT JOIN Departments AS D ON D.DepartmentID = E.DepartmentID
	ORDER BY E.EmployeeID