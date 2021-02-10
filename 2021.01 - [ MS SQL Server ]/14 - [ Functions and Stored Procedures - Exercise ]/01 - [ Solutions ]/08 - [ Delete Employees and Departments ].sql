-- First solution

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL
	 
	DELETE 
		FROM EmployeesProjects
		WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	 
	UPDATE 
		Employees
		SET ManagerID = NULL
	 	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	 
	UPDATE
		Employees
		SET ManagerID = NULL
	 	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	 
	UPDATE 
		Departments
	   	SET ManagerID = NULL
	 	WHERE DepartmentID = @departmentId
	 
	DELETE 
		FROM Employees 
		WHERE DepartmentID = @departmentId
	 
	DELETE 
		FROM Departments
		WHERE DepartmentID = @departmentId
	 
	SELECT 
		COUNT(*) 
		FROM Employees 
		WHERE DepartmentID = @departmentId
END

-- Second solution

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN

	ALTER TABLE 
		Departments
		ALTER COLUMN ManagerID INT 

	DELETE 
		ep
		FROM EmployeesProjects ep
		JOIN Employees e ON e.EmployeeID = ep.EmployeeID
		WHERE e.DepartmentID = @departmentId

	ALTER TABLE 
		Employees
		ALTER COLUMN DepartmentID INT 

	UPDATE 
		Departments
		SET ManagerID = NULL
		WHERE DepartmentID = @departmentId

	UPDATE 
		t2
		SET t2.ManagerID = NULL
		FROM Employees AS t1
		INNER JOIN Employees AS t2 ON t1.EmployeeID = t2.ManagerID
		WHERE t1.DepartmentID = @departmentId

	UPDATE 
		Employees
		SET ManagerID = NULL
		WHERE DepartmentID = @departmentId

	UPDATE 
		t1
		SET t1.ManagerID = NULL
		FROM Employees AS t1
		JOIN Departments AS t2
		ON t1.EmployeeID = t2.ManagerID
		WHERE t1.DepartmentID = @departmentId

	UPDATE 
		t1
		SET t1.DepartmentID = NULL
		FROM Employees AS t1
		JOIN Departments AS t2 ON t1.DepartmentID = t2.DepartmentID
		WHERE t1.DepartmentID = @departmentId

	DELETE 
		FROM Departments 
		WHERE DepartmentID = @departmentId

	DELETE
		FROM Employees
		WHERE DepartmentID = @departmentId

	SELECT 
		COUNT(*) 
		FROM Employees 
		WHERE DepartmentID = @departmentId

END

--EXEC usp_DeleteEmployeesFromDepartment 7