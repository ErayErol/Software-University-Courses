SELECT
	PeakName, 
	RiverName, 
	LOWER(LEFT(PeakName, LEN(PeakName) -1) + RiverName) AS Mix
	FROM Peaks,Rivers
    WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
    ORDER BY Mix