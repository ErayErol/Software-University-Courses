SELECT *
	INTO Newtable 
	FROM Employees
	WHERE Salary > 30000

DELETE 
	FROM Newtable 
	WHERE ManagerID = 42

UPDATE 
	Newtable
	SET Salary = Salary + 5000
	WHERE DepartmentID = 1

SELECT 
	DepartmentID,
	AVG(Salary) AverageSalary
	FROM Newtable 
	GROUP BY DepartmentID
