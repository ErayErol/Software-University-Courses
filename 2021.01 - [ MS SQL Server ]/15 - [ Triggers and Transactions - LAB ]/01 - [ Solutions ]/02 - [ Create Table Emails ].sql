CREATE TABLE NotificationEmails 
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
	[Subject] NVARCHAR(150) NOT NULL, 
	[Body] NVARCHAR(200) NOT NULL
)

-- For Judge
CREATE TRIGGER tr_NotificationEmail ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, [Subject], [Body])
	SELECT i.LogId,
		   'Balance change for account: ' + CAST(i.AccountId AS NVARCHAR(20)),
		   'On ' 
		       + CAST(GETDATE() AS NVARCHAR(50)) 
			   + ' your balance was changed from ' 
			   + CAST(i.OldSum AS NVARCHAR(20)) 
			   + ' to ' 
			   + CAST(i.NewSum AS NVARCHAR(20)) 
			   + '.'
	FROM inserted i
END
--

UPDATE Accounts SET Balance -= 10 WHERE Id = 1
SELECT * FROM Accounts
SELECT * FROM Logs
SELECT * FROM NotificationEmails