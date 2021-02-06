CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION

DECLARE @currentEmployeeID INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @emloyeeId)
DECLARE @currentProjectID INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectID)

IF(@currentEmployeeID IS NULL)
  BEGIN
    ROLLBACK
	RAISERROR('Invalid Employee Id!', 16, 1)
	RETURN
  END

IF(@currentProjectID IS NULL)
  BEGIN
    ROLLBACK
	 RAISERROR('Invalid Project Id!', 16, 1)
	 RETURN
  END

DECLARE @countOfProjects INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)
IF(@countOfProjects >= 3)
  BEGIN
    ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 1)
	RETURN
  END

  INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	VALUES (@emloyeeId, @projectID);
COMMIT

SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = 1
SELECT * FROM EmployeesProjects
usp_AssignProject 1, 39