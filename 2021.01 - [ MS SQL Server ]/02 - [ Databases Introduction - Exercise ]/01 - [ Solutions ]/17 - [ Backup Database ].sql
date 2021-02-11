BACKUP DATABASE SoftUni
TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\softuni-backup.bak' 
WITH NOFORMAT, NOINIT,  
NAME = N'SoftUni-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO

USE Bank
DROP DATABASE SoftUni

RESTORE DATABASE SoftUni 
FROM DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\softuni-backup.bak'  WITH  FILE = 1,  NOUNLOAD,  STATS = 5
GO