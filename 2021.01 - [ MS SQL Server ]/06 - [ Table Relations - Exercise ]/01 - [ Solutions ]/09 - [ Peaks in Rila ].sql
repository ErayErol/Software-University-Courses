SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation
FROM Peaks
INNER JOIN Mountains ON Peaks.MountainId = 17
WHERE Mountains.MountainRange = 'Rila'
ORDER BY Peaks.Elevation DESC