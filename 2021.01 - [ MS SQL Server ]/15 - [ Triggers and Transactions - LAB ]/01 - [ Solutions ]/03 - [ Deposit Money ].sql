-- For Judge
CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
 DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
  IF(@account IS NULL)
  BEGIN
    ROLLBACK
	RAISERROR('Invalid Account Id!', 16, 1)
	RETURN
  END
  IF(@moneyAmount <= 0)
  BEGIN
    ROLLBACK
	RAISERROR('Money amount cannot be zero or negative!', 16, 1)
	RETURN
  END

  UPDATE Accounts 
    SET Balance += @moneyAmount 
      WHERE Id = @accountId
COMMIT
--

SELECT * FROM Accounts

EXEC usp_DepositMoney 1, 100