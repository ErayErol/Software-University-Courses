SELECT
	E.EmployeeID, 
	E.FirstName, 
	E.LastName, 
	D.[Name] AS DepartmentName
	FROM Employees AS E
	JOIN Departments AS D ON D.DepartmentID = E.DepartmentID
	WHERE D.[Name] = 'Sales'
	ORDER BY E.EmployeeID