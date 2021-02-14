SELECT 
	TOP(5)
	e.EmployeeID, 
	e.JobTitle, 
	a.AddressID, 
	a.AddressText
	FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID
	ORDER BY a.AddressID