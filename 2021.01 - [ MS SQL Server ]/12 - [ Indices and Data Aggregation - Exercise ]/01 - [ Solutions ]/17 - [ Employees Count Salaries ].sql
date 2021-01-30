SELECT 
	SUM(EmployeeWithoutManager.SalaryCounts) AS [Count]
FROM (
	SELECT 
		DepartmentID,
		COUNT(Salary) AS SalaryCounts
	  FROM Employees
		WHERE ManagerID IS NULL
GROUP BY DepartmentID) AS EmployeeWithoutManager