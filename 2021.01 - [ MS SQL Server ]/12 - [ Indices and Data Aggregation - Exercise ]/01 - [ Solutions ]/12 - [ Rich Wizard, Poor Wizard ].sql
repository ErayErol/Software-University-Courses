SELECT
	mc.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
  FROM MountainsCountries mc
	JOIN Mountains m ON m.Id = mc.MountainId
	JOIN Peaks p ON p.MountainId = m.Id
  WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC