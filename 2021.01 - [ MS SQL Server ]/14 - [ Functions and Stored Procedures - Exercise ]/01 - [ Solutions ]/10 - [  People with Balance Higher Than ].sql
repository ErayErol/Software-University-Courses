CREATE PROC usp_GetHoldersWithBalanceHigherThan(@inputSalary MONEY)
AS
BEGIN
SELECT 
	ah.FirstName,
	ah.LastName
	FROM Accounts a
	JOIN AccountHolders ah ON ah.Id = a.AccountHolderId
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @inputSalary
	ORDER BY ah.FirstName, ah.LastName
END

--GO

--EXEC usp_GetHoldersWithBalanceHigherThan 50000