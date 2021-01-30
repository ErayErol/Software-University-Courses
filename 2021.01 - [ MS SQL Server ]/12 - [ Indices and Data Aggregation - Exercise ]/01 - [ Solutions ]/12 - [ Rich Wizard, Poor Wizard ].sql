-- Start reading from last SELECT to first SELECT and you will understand it. :)

SELECT 
	SUM(b.[Difference]) AS SumDifference 
FROM (
	SELECT -- Start b
		CASE
		    WHEN a.Id = (SELECT TOP (1) Id FROM WizzardDeposits ORDER BY Id DESC)
		  	THEN (a.[Current] - a.[Current])
		    ELSE (a.[Current] - a.[Next])
		END AS [Difference]
	FROM (
		SELECT -- Start a
			Id,
			DepositAmount AS [Current],
			LEAD(DepositAmount, 1,0) OVER (ORDER BY Id) AS [Next]
		FROM WizzardDeposits)
		AS a)  -- End a
	AS b -- End b