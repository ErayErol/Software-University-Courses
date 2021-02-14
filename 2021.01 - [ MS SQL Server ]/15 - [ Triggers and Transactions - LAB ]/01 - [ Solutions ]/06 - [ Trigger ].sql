-- 1
CREATE TRIGGER tr_RestrictItem ON UserGameItems FOR INSERT
AS
BEGIN
    INSERT INTO 
		UserGameItems 
		(ItemId, UserGameId)
		SELECT 
		i.ItemId, 
		i.UserGameId
		FROM inserted i
		JOIN Items it ON it.Id = i.ItemId
		JOIN UsersGames ug ON ug.Id = i.UserGameId
		JOIN Users u ON u.Id = ug.UserId
		WHERE ug.[Level] >= it.MinLevel	

END

-- 2

UPDATE 
	UsersGames
	SET Cash += 50000
	WHERE GameId = 212

-- 3

DECLARE @indexId INT = 251;
	
WHILE @indexId < 300
BEGIN
	
	INSERT INTO 
		UserGameItems 
		(ItemId, UserGameId)
		SELECT 
		@indexId, 
		ug.GameId
		FROM Items i, UsersGames ug
		WHERE ug.GameId = 212
		SET @indexId += 1;

END