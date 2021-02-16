namespace Demo
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Data;

    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=Bitbucket"))
            {
                connection.Open();

                Console.WriteLine("Exercise 5 From My Last SQL Exam");

                string five = @"SELECT 
	                                Id, 
	                                [Message], 
	                                RepositoryId, 
	                                ContributorId
	                                FROM Commits 
	                                ORDER BY Id, [Message], RepositoryId, ContributorId";

                SqlCommand sqlCommand = new SqlCommand(five, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;
                        Console.WriteLine($"{record["Id"]} - {record["Message"]} - {record["RepositoryId"]} - {record["ContributorId"]}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Exercise 6 From My Last SQL Exam");

                string six = @"SELECT 
	                                Id, 
	                                [Name],
	                                Size 
	                                FROM Files 
	                                WHERE Size > 1000 AND [Name] LIKE '%html%' 
	                                ORDER BY Size DESC, Id, [Name]";

                sqlCommand = new SqlCommand(six, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;
                        Console.WriteLine($"{record["Id"]} - {record["Name"]} - {record["Size"]}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Exercise 7 From My Last SQL Exam");

                string seven = @"SELECT 
	                                I.Id,
	                                CAST(CONCAT(U.Username, ' : ', I.Title) AS VARCHAR(MAX)) AS IssueAssignee
	                                FROM Issues I 
	                                JOIN Users U ON U.Id = I.AssigneeId 
	                                ORDER BY I.Id DESC, I.AssigneeId";

                sqlCommand = new SqlCommand(seven, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;
                        Console.WriteLine($"{record["Id"]} - {record["IssueAssignee"]}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Exercise 8 From My Last SQL Exam");

                string eight = @"SELECT 
	                                F.Id, 
	                                F.[Name], 
	                                CONCAT(F.Size, 'KB') AS Size
	                                FROM Files F 
	                                LEFT JOIN Files FL ON FL.ParentId = F.Id 
	                                WHERE FL.Id IS NULL
	                                ORDER BY F.Id, F.[Name], F.Size DESC";

                sqlCommand = new SqlCommand(eight, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;
                        Console.WriteLine($"{record["Id"]} - {record["Name"]} - {record["Size"]}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Exercise 9 From My Last SQL Exam");

                string nine = @"SELECT 
	                                TOP 5
	                                R.Id, 
                                    R.Name, 
                                    COUNT(*) AS Commits
	                                FROM RepositoriesContributors RC
	                                JOIN Repositories R ON R.Id = RC.RepositoryId
	                                JOIN Commits C ON C.RepositoryId = R.Id
	                                GROUP BY R.Id, R.Name
	                                ORDER BY Commits DESC, R.Id, R.Name";

                sqlCommand = new SqlCommand(nine, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;
                        Console.WriteLine($"{record["Id"]} - {record["Name"]} - {record["Commits"]}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Exercise 10 From My Last SQL Exam");

                string ten = @"SELECT 
                                    U.Username,
                                    AVG(F.Size) AS Size
                                    FROM Commits C 
                                    JOIN Users U ON U.Id = C.ContributorId
                                    JOIN Files F ON F.CommitId = C.Id
                                    GROUP BY U.Username
                                    ORDER BY Size DESC, U.Username";

                sqlCommand = new SqlCommand(ten, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = (IDataRecord)reader;
                        Console.WriteLine($"{record["Username"]} - {record["Size"]}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Exercise 11 From My Last SQL Exam");

                string createFunction = @"CREATE OR ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
                                  RETURNS VARCHAR(MAX)
                                  AS
                                  BEGIN
                                  	
                                  	DECLARE @id INT = (SELECT Id FROM Users WHERE Username = @username)
                                  	
                                  	DECLARE @result VARCHAR(MAX) = (SELECT COUNT(Id) FROM Commits WHERE ContributorId = @id)
                                  
                                  	RETURN @result
                                  
                                  END";

                sqlCommand = new SqlCommand(createFunction, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                }

                string eleven = @"SELECT dbo.udf_AllUserCommits('UnderSinduxrein')";

                sqlCommand = new SqlCommand(eleven, connection);

                var allUserCommits = sqlCommand.ExecuteScalar();
                Console.WriteLine(allUserCommits);

                sqlCommand.Dispose();

                Console.WriteLine();
                Console.WriteLine("Exercise 12 From My Last SQL Exam");

                string createProcedure = @"CREATE OR ALTER PROC usp_SearchForFiles(@fileExtension VARCHAR(MAX))
                                            AS
                                            BEGIN
                                            
                                            	SELECT 
                                            		Id, 
                                            		[Name], 
                                            		CONCAT(Size, 'KB') AS Size
                                            		FROM Files 
                                            		WHERE [Name] LIKE '%' + @fileExtension + '%'
                                            
                                            END";

                sqlCommand = new SqlCommand(createProcedure, connection);

                using (var reader = sqlCommand.ExecuteReader())
                {
                }

                string twelve = @"EXEC usp_SearchForFiles 'txt'";

                sqlCommand = new SqlCommand(twelve, connection);

                using (var files = sqlCommand.ExecuteReader())
                {
                    while (files.Read())
                    {
                        var record = (IDataRecord)files;
                        Console.WriteLine($"{record["Id"]} - {record["Name"]} - {record["Size"]}");
                    }
                }
            }
        }
    }
}