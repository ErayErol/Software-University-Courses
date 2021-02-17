namespace VillainNames
{
    using Microsoft.Data.SqlClient;
    using System;

    class Program
    {
        private const string sqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(sqlConnectionString);
            connection.Open();

            VillianNames(connection);
        }

        private static void VillianNames(SqlConnection connection)
        {
            var query = @"SELECT 
	                    V.[Name],
	                    COUNT(MV.MinionId) as CountOfMinions
	                    FROM Villains V
	                    JOIN MinionsVillains MV ON MV.VillainId = V.Id
	                    JOIN Minions M ON M.Id = MV.MinionId
	                    GROUP BY V.Id, V.[Name]
                        HAVING COUNT(MV.MinionId) > 3
                        ORDER BY CountOfMinions DESC";

            using var sqlCommand = new SqlCommand(query, connection);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var name = reader[0];
                var count = reader[1];

                Console.WriteLine($"{name} - {count}");
            }
        }
    }
}