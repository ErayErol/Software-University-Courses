-- 1. Execute from Start a to End a
-- 2. Execute from Start b to End b
-- 3. Execute from Start to End
-- 4. I hope you understand it. :)

SELECT -- Start
	SUM(b.[Difference]) AS SumDifference 
FROM (
	SELECT -- Start b
		a.[Current] - a.[Next]AS [Difference]
	FROM (
		SELECT -- Start a
			DepositAmount AS [Current],
			LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS [Next]
		FROM WizzardDeposits -- End a
	)AS a  -- End b
)AS b -- End

/*
Other solution
SELECT 
	SUM(Guest.DepositAmount - Host.DepositAmount) AS [SumDifference]
  FROM WizzardDeposits Host
JOIN WizzardDeposits Guest ON Guest.Id + 1 = Host.Id
*/