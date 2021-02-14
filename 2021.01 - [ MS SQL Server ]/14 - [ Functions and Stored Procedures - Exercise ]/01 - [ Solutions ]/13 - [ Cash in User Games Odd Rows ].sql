CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN(
	SELECT 
	SUM(k.[Sum]) AS SumCash
	FROM (SELECT  
	SUM(ug.Cash) AS [Sum], 
	ROW_NUMBER() OVER (PARTITION BY ug.GameId ORDER BY ug.Cash DESC) AS RowNumber
	FROM Games g 
	JOIN UsersGames ug ON ug.GameId = g.Id
	GROUP BY ug.GameId, g.[Name], ug.Cash
	HAVING g.[Name] = @gameName) AS k
	WHERE k.RowNumber % 2 = 1)

--GO

--SELECT 
--	* 
--	FROM dbo.ufn_CashInUsersGames('Love in a mist')