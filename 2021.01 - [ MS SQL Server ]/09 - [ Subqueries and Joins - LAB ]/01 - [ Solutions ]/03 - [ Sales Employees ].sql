SELECT
	e.FirstName, e.LastName, e.HireDate, d.[Name] AS DepartmentName
  FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
  WHERE e.HireDate > '1999-01-01' AND
		(d.[Name] IN ('Sales', 'Finance'))
  ORDER BY e.HireDate