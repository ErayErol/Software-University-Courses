SELECT 
	M.MountainRange, 
	P.PeakName, 
	P.Elevation
	FROM Peaks P
	JOIN Mountains M ON M.Id = P.MountainId
	WHERE P.MountainId = 17
	ORDER BY P.Elevation DESC