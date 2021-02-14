USE SoftUni

GO

CREATE FUNCTION udf_EmployeeListByDepartment(@DepName nvarchar(20))
RETURNS @result 
TABLE
(
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    DepartmentName nvarchar(20) NOT NULL
) 
AS
BEGIN

    WITH 
		Employees_CTE 
		(FirstName, LastName, DepartmentName) AS(
        SELECT 
		e.FirstName, 
		e.LastName, 
		d.[Name]
        FROM Employees AS e 
        LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID)

    INSERT INTO 
		@result 
		SELECT 
		FirstName, 
		LastName, 
		DepartmentName 
		FROM Employees_CTE WHERE DepartmentName = @DepName

	RETURN
END

GO

SELECT * FROM dbo.udf_EmployeeListByDepartment('Engineering')