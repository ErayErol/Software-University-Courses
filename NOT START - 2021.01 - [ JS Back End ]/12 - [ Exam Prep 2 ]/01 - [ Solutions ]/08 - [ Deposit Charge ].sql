SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge)
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator