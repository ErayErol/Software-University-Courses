SELECT
[Name],
DATEDIFF(YEAR, Birthdate,  GETDATE()) AS [Years],
DATEDIFF(MONTH, Birthdate,  GETDATE()) AS [Months],
DATEDIFF(DAY, Birthdate,  GETDATE()) AS [Days],
DATEDIFF(HOUR, Birthdate,  GETDATE()) AS [Hours],
DATEDIFF(MINUTE, Birthdate,  GETDATE()) AS [Minutes]
FROM HowManyYearsMonthsDaysMinutesILive