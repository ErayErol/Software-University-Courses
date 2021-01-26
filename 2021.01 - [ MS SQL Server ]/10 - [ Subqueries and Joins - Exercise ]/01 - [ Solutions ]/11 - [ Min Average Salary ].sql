WITH GroupedDepartmentsByAvgSalary (DepartmentID, AverageSalary) AS
(
  SELECT e.DepartmentID, 
		 AVG(e.Salary) AS AverageSalary
	FROM Employees AS e
	 GROUP BY e.DepartmentID
)

SELECT MIN(AverageSalary) AS MinAverageSalary
  FROM GroupedDepartmentsByAvgSalary

--SELECT d.[Name], gd.AverageSalary
--  FROM GroupedDepartmentsByAvgSalary gd
--	JOIN Departments d ON d.DepartmentID = gd.DepartmentID
--ORDER BY gd.AverageSalary