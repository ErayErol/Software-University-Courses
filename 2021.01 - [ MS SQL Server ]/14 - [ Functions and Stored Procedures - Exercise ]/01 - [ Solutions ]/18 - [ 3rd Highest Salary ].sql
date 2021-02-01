SELECT
	em.DepartmentID,
	em.Salary AS [ThirdHighestSalary]
  FROM (
	SELECT 
	  e.DepartmentID,
	  e.Salary,
	  ROW_NUMBER() OVER(PARTITION BY e.DepartmentID ORDER BY MAX(e.Salary) DESC) AS [Row]
	FROM Employees e
  GROUP BY e.DepartmentID, e.Salary) AS em
WHERE em.[Row] = 3