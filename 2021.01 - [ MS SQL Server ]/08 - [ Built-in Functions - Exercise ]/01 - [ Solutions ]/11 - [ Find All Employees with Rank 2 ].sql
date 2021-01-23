SELECT * FROM
(
	SELECT 
		EmployeeID,
		FirstName, 
		LastName, 
		Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
		FROM Employees
		WHERE (Salary BETWEEN 10000 AND 50000)
) AS OrderEmployees
	WHERE OrderEmployees.Rank = 2
	ORDER BY OrderEmployees.Salary DESC

--CREATE VIEW V_OrderEmployees AS
--	SELECT 
--		EmployeeID,
--		FirstName, 
--		LastName, 
--		Salary,
--		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
--		FROM Employees
--		WHERE (Salary BETWEEN 10000 AND 50000)

--SELECT * FROM V_OrderEmployees
--	WHERE [Rank] = 2
--		ORDER BY Salary DESC