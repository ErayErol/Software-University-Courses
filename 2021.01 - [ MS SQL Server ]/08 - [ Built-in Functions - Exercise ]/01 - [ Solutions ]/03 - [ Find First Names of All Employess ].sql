SELECT 
	FirstName
	FROM Employees
	WHERE (DepartmentID = 3 OR DepartmentID = 10) AND 
	  HireDate BETWEEN '1995-01-01' AND '2005-12-31'