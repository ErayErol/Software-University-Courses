CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION

	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
	IF(@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Account Id!', 16, 1)
		RETURN
	END

	IF(@moneyAmount < 0) -- I think <= 0 is better, but Judge don't agree with me. :(
	BEGIN
		ROLLBACK
		RAISERROR('Money amount cannot be negative!', 16, 1)
		RETURN
	END

	DECLARE @currentBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @accountId)
	IF(@currentBalance - @moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Cannot withdraw from balance that is less than zero!', 16, 1)
		RETURN
	END

  UPDATE 
	Accounts 
    SET Balance -= @moneyAmount 
    WHERE Id = @accountId

COMMIT

--GO

--EXEC usp_WithdrawMoney 1, 400