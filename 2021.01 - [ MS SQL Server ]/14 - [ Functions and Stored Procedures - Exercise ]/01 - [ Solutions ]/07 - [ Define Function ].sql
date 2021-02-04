CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
  DECLARE @i TINYINT = 1;

  WHILE LEN(@word) >= @i
  BEGIN
    DECLARE @currentLetter NVARCHAR(1) = SUBSTRING(@word, @i, 1);

    IF(@setOfLetters NOT LIKE '%' + @currentLetter + '%') -- IF(CHARINDEX(@currentLetter, @setOfLetters) = 0)
	  RETURN 0

    SET @i += 1;
  END

  RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')

SELECT dbo.ufn_IsWordComprised('ryae', 'Erays')