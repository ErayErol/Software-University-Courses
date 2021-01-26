SELECT
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(e2.FirstName, ' ', e2.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
  FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	JOIN Employees AS e2 ON e2.EmployeeID = e.ManagerID
  ORDER BY e.EmployeeID