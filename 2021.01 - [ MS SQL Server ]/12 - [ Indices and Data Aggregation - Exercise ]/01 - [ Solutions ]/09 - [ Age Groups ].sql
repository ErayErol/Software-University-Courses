--SELECT * FROM WizzardDeposits

SELECT 
	Age,
	COUNT(Age) AS CountOfAge,
	NTILE(7) OVER(ORDER BY Age) AS [Group]
  FROM WizzardDeposits
	GROUP BY Age
  ORDER BY Age

SELECT 
	Age,
	NTILE(7) OVER(ORDER BY Age) AS [Group]
  FROM WizzardDeposits
