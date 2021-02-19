SELECT 
	LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits
    GROUP BY DepositGroup, LEFT(FirstName, 1)
	HAVING DepositGroup = 'Troll Chest'
	ORDER BY LEFT(FirstName, 1)