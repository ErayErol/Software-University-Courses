SELECT 
	TOP(5)
	CountryName, 
	ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	IIF(Elevation IS NULL, 0, Elevation) AS [Highest Peak Elevation],
	ISNULL(MountainRange, '(no mountain)') AS [Mountain]
	FROM(
	SELECT
	CountryName, 
	PeakName, 
	Elevation, 
	MountainRange,
	DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	) AS Ranked
	WHERE Ranked.[Rank] = 1
	ORDER BY Ranked.CountryName, Ranked.PeakName