-- First function
CREATE FUNCTION udf_SumOfTwoNumber (@FirstNum TINYINT, @SecondNum TINYINT)
RETURNS TINYINT
AS
BEGIN
	DECLARE @SumOfNumbers TINYINT = @FirstNum + @SecondNum;
	RETURN @SumOfNumbers
END

SELECT dbo.udf_SumOfTwoNumber(1,2) AS Result

-- Second function
CREATE FUNCTION udf_ProjectDurationWeeks (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
    DECLARE @projectWeeks INT;
    IF(@EndDate IS NULL)
    BEGIN
        SET @EndDate = GETDATE()
    END
    SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
    RETURN @projectWeeks;
END

SELECT * FROM Projects
SELECT dbo.udf_ProjectDurationWeeks('2002-06-01 00:00:00', '2003-06-01 00:00:00') AS Result