CREATE PROC usp_CalculateFutureValueForAccount (@accountID INT ,@interestRate FLOAT)
AS
BEGIN

	SELECT
		a.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
		FROM Accounts a
		JOIN AccountHolders ah ON ah.Id = a.AccountHolderId
		WHERE a.Id = @accountID

END

--GO

--usp_CalculateFutureValueForAccount 1, 0.1