CREATE PROCEDURE dbo.usp_AddNumbers (@firstNumber SMALLINT, @secondNumber SMALLINT, @result INT OUTPUT)
AS
BEGIN
   SET @result = @firstNumber + @secondNumber
END

GO

DECLARE @answer smallint
EXECUTE usp_AddNumbers 5, 6, @answer OUTPUT
SELECT 'The result is: ', @answer

-- The result is: 11