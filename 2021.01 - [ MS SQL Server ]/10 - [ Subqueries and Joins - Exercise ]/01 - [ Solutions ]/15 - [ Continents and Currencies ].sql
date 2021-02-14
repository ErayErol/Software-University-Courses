SELECT 
	ContinentCode, 
	CurrencyCode, 
	CurrencyUsage 
	FROM(
	SELECT
	ContinentCode,
	CurrencyCode,
	COUNT(CurrencyCode) AS CurrencyUsage,
	DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS [Rank]
    FROM Countries
    GROUP BY ContinentCode, CurrencyCode
	) AS Ranked
	WHERE Ranked.[Rank] = 1 AND Ranked.CurrencyUsage > 1
	ORDER BY ContinentCode