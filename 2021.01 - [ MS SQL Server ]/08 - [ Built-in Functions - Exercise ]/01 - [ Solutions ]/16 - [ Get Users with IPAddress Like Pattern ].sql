SELECT 
	Username, 
	IpAddress 
	FROM Users
	WHERE IpAddress LIKE ('[0-9][0-9][0-9].[1]%.[0-9][0-9][0-9]')
	ORDER BY Username

--SELECT 
--	Username, 
--	IpAddress 
--	FROM Users
--	WHERE IpAddress LIKE ('___.[1]%.___')
--	ORDER BY Username