SELECT * FROM
(
	SELECT 
		Username,
		SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) [Email Provider]
		FROM Users
) AS [EP]
	ORDER BY [Email Provider], Username