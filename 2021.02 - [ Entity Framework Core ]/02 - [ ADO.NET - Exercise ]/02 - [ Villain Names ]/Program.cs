namespace VillainNames
{
    using Microsoft.Data.SqlClient;
    using System;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            // When we use "using declaration" automatically at the end of the current code block will invoke the method Dispose
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            Print(connection);
        } // Dispose method of connection automatically will be invoked after current code block

        private static void Print(SqlConnection connection)
        {
            // If we have nested *using*
            // I use "using statement" instead of "using declaration"
            // Because for me it's more clear when Dispose method will be invoked
            var query = @"SELECT V.[Name], COUNT(MV.MinionId) as CountOfMinions FROM Villains V JOIN MinionsVillains MV ON MV.VillainId = V.Id 
                            JOIN Minions M ON M.Id = MV.MinionId GROUP BY V.Id, V.[Name] HAVING COUNT(MV.MinionId) > 3 ORDER BY CountOfMinions DESC";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0];
                        var count = reader[1];

                        Console.WriteLine($"{name} - {count}");
                    }
                }
            }
        }
    }
}