SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd', 'bg-BG') AS [Start]
FROM [Games]
WHERE DATEPART(YEAR, [Start]) > 2010 AND
DATEPART(YEAR, [Start]) < 2013
ORDER BY [Start], [Name]