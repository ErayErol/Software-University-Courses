-- For Judge
CREATE PROC usp_TransferMoney (@senderId INT, @receiverId INT, @amount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
  EXEC usp_WithdrawMoney @senderId, @amount
  EXEC usp_DepositMoney @receiverId, @amount
COMMIT
--

EXEC usp_TransferMoney 5, 1, 5000

EXEC usp_TransferMoney 1, 5, 5000

SELECT * FROM Accounts WHERE Id IN (1,5)