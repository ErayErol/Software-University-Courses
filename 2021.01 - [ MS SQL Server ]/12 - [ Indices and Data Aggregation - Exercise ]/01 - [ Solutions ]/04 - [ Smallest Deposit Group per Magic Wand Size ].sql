SELECT TOP(2)
	k.DepositGroup 
  FROM(
	SELECT 
	  DepositGroup, 
	  AVG(MagicWandSize) AverageMagicWandSize
	FROM WizzardDeposits
  GROUP BY DepositGroup) AS k
ORDER BY k.AverageMagicWandSize