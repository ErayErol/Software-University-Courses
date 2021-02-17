namespace MinionNames
{
    using Microsoft.Data.SqlClient;
    using System;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            var villainId = int.Parse(Console.ReadLine() ?? string.Empty);

            var villain = GetVillain(connection, villainId);

            if (IfVillainNotExists(villain, villainId, out var villainName))
            {
                return;
            }

            var minions = GetMinions(connection, villainId);
            using var reader = minions.ExecuteReader();

            PrintResult(reader, villainName);
        }

        private static void PrintResult(SqlDataReader reader, string villainName)
        {
            Console.WriteLine($"Villain: {villainName}");

            if (reader.HasRows == false)
            {
                Console.WriteLine("(no minions)");
                return;
            }

            while (reader.Read())
            {
                var rowNumber = reader[0];
                var minionName = reader[1];
                var age = reader[2];
                Console.WriteLine($"{rowNumber}. {minionName} {age}");
            }
        }

        private static SqlCommand GetMinions(SqlConnection connection, int villainId)
        {
            var query = @"SELECT 
                            ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                            m.Name, 
                            m.Age
                            FROM MinionsVillains AS mv
                            JOIN Minions As m ON mv.MinionId = m.Id
                            WHERE mv.VillainId = @Id
                            ORDER BY m.Name";

            using var sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Id", villainId);
            return sqlCommand;
        }

        private static bool IfVillainNotExists(SqlCommand villain, int villainId, out string villainName)
        {
            villainName = villain.ExecuteScalar() as string;
            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return true;
            }

            return false;
        }

        private static SqlCommand GetVillain(SqlConnection connection, int villainId)
        {
            var query = @"SELECT Name FROM Villains WHERE Id = @Id";
            using var sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Id", villainId);
            return sqlCommand;
        }
    }
}
