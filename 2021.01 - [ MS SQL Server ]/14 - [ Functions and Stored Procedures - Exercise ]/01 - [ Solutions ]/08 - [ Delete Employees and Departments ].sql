--CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
--AS
--ALTER TABLE Departments
--ALTER COLUMN ManagerID INT NULL
 
--DELETE FROM EmployeesProjects
-- WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
 
--UPDATE Employees
--  SET ManagerID = NULL
--WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
 
--UPDATE Employees
--  SET ManagerID = NULL
--WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
 
--UPDATE Departments
--  SET ManagerID = NULL
--WHERE DepartmentID = @departmentId
 
--DELETE FROM Employees 
-- WHERE DepartmentID = @departmentId
 
--DELETE FROM Departments
-- WHERE DepartmentID = @departmentId

--SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
--1
ALTER TABLE Departments
ALTER COLUMN ManagerID INT 

--2
DELETE ep
  FROM EmployeesProjects ep
	JOIN Employees e ON e.EmployeeID = ep.EmployeeID
	WHERE e.DepartmentID = @departmentId

--3
ALTER TABLE Employees
ALTER COLUMN DepartmentID INT 

--4
UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

--5
UPDATE t2
  SET t2.ManagerID = NULL
  FROM Employees AS t1
  INNER JOIN Employees AS t2
  ON t1.EmployeeID = t2.ManagerID
  WHERE t1.DepartmentID = @departmentId

--6
UPDATE Employees
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

--7
UPDATE t1
  SET t1.ManagerID = NULL
  FROM Employees AS t1
  JOIN Departments AS t2
  ON t1.EmployeeID = t2.ManagerID
  WHERE t1.DepartmentID = @departmentId

--8
UPDATE t1
  SET t1.DepartmentID = NULL
  FROM Employees AS t1
  JOIN Departments AS t2
  ON t1.DepartmentID = t2.DepartmentID
  WHERE t1.DepartmentID = @departmentId

--9
DELETE d
  FROM Departments d
WHERE DepartmentID = @departmentId

--10
DELETE
  FROM Employees
WHERE DepartmentID = @departmentId

SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 7