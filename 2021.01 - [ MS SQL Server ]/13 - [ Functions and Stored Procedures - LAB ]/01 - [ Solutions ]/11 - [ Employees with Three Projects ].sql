CREATE PROCEDURE udp_AssignProject
	(@EmployeeID INT, @ProjectID INT)
AS
BEGIN
	DECLARE @maxEmployeeProjectsCount INT = 3
	DECLARE @employeeProjectsCount INT
		SET @employeeProjectsCount = 
(SELECT COUNT(*) 
   FROM [dbo].[EmployeesProjects] AS ep
   WHERE ep.EmployeeId = @EmployeeID)
   --INSERT NEW DATA
END

IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
BEGIN
   THROW 50001, 'The employee has too many projects!', 1;
END

INSERT INTO [dbo].[EmployeesProjects]
(EmployeeID, ProjectID)VALUES (@EmployeeID, @ProjectID)

EXEC udp_AssignProject 2,4