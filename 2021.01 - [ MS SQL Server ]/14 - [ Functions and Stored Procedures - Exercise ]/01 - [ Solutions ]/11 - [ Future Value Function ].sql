CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @numberOfyears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
DECLARE @x FLOAT = 1 + @yearlyInterestRate;
DECLARE @calculate DECIMAL(18,4) = @sum * (POWER(@x, @numberOfyears));
RETURN @calculate 
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)