namespace Demo
{
    internal class Query
    {
        internal static string StatementSelectExercise5
            => @"SELECT 
	                 Id, 
	                 [Message], 
	                 RepositoryId, 
	                 ContributorId
	                 FROM Commits 
	                 ORDER BY Id, [Message], RepositoryId, ContributorId";

        internal static string StatementSelectExercise6
            => @"SELECT 
	                 Id, 
	                 [Name],
	                 Size 
	                 FROM Files 
	                 WHERE Size > 1000 AND [Name] LIKE '%html%' 
	                 ORDER BY Size DESC, Id, [Name]";

        internal static string StatementSelectExercise7
            => @"SELECT 
	                 I.Id,
	                 CAST(CONCAT(U.Username, ' : ', I.Title) AS VARCHAR(MAX)) AS IssueAssignee
	                 FROM Issues I 
	                 JOIN Users U ON U.Id = I.AssigneeId 
	                 ORDER BY I.Id DESC, I.AssigneeId";

        internal static string StatementSelectExercise8
            => @"SELECT 
	                 F.Id, 
	                 F.[Name], 
	                 CONCAT(F.Size, 'KB') AS Size
	                 FROM Files F 
	                 LEFT JOIN Files FL ON FL.ParentId = F.Id 
	                 WHERE FL.Id IS NULL
	                 ORDER BY F.Id, F.[Name], F.Size DESC";

        internal static string StatementSelectExercise9
            => @"SELECT 
	                 TOP 5
	                 R.Id, 
                     R.Name, 
                     COUNT(*) AS Commits
	                 FROM RepositoriesContributors RC
	                 JOIN Repositories R ON R.Id = RC.RepositoryId
	                 JOIN Commits C ON C.RepositoryId = R.Id
	                 GROUP BY R.Id, R.Name
	                 ORDER BY Commits DESC, R.Id, R.Name";

        internal static string StatementSelectExercise10
            => @"SELECT 
                     U.Username,
                     AVG(F.Size) AS Size
                     FROM Commits C 
                     JOIN Users U ON U.Id = C.ContributorId
                     JOIN Files F ON F.CommitId = C.Id
                     GROUP BY U.Username
                     ORDER BY Size DESC, U.Username";

        internal static string StatementSelectExercise11
            => @"SELECT dbo.udf_AllUserCommits('UnderSinduxrein')";

        internal static string StatementSelectExercise12
            => @"EXEC usp_SearchForFiles 'txt'";

        internal static string CreateFunctionExercise11
            => @"CREATE OR ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
                     RETURNS VARCHAR(MAX)
                     AS
                     BEGIN
                     	
                     	DECLARE @id INT = (SELECT Id FROM Users WHERE Username = @username)
                     	
                     	DECLARE @result VARCHAR(MAX) = (SELECT COUNT(Id) FROM Commits WHERE ContributorId = @id)
                     
                     	RETURN @result
                     
                     END";

        internal static string CreateProcedureExercise12
            => @"CREATE OR ALTER PROC usp_SearchForFiles(@fileExtension VARCHAR(MAX))
                     AS
                     BEGIN
                     
                     	SELECT 
                     		Id, 
                     		[Name], 
                     		CONCAT(Size, 'KB') AS Size
                     		FROM Files 
                     		WHERE [Name] LIKE '%' + @fileExtension + '%'
                     
                     END";
    }
}
