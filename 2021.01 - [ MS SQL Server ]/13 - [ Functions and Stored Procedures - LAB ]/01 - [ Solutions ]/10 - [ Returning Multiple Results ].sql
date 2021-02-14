CREATE PROC usp_MultipleResults
AS
BEGIN
	SELECT 
		FirstName, 
		LastName 
		FROM Employees
	
	SELECT 
		FirstName, 
		LastName, 
		d.[Name] AS Department 
		FROM Employees AS e 
		JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
END

GO

EXEC usp_MultipleResults