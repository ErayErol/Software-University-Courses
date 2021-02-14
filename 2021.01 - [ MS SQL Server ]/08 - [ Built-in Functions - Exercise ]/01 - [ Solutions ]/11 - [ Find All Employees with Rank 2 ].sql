SELECT * 
	FROM(
	SELECT 
	EmployeeID,
	FirstName,
	LastName, 
	Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE (Salary BETWEEN 10000 AND 50000)
	) AS OrderEmployees
	WHERE OrderEmployees.[Rank] = 2
	ORDER BY OrderEmployees.Salary DESC

--WITH 
--	EmployeesWithRank2 
--	(EmployeeID, FirstName, LastName, Salary, [Rank]) AS
--	(
--	SELECT 
--	EmployeeID,
--	FirstName, 
--	LastName, 
--	Salary,
--	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
--	FROM Employees
--	WHERE Salary BETWEEN 10000 AND 50000
--	)

--SELECT *
--	FROM EmployeesWithRank2
--	WHERE [Rank] = 2
--	ORDER BY Salary DESC