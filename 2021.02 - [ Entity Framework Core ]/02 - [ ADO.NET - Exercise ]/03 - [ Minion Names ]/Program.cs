namespace MinionNames
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
            var villainId = ReadInput();
            var villainName = VillainName(connection, villainId);
            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                PrintResult(connection, villainName, villainId);
            }
        } // Dispose method of connection automatically will be invoked after current code block

        private static void PrintResult(SqlConnection connection, string villainName, int villainId)
        {
            using var reader = SqlDataReader(connection, villainId);
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
        } // Dispose method of reader automatically will be invoked after current code block

        private static SqlDataReader SqlDataReader(SqlConnection connection, int villainId)
        {
            var query = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum, m.Name, m.Age FROM MinionsVillains AS mv 
                            JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = @Id ORDER BY m.Name";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", villainId);
            var reader = command.ExecuteReader();
            return reader;
        } // Dispose method of connection automatically will be invoked after current code block

        private static string VillainName(SqlConnection connection, int villainId)
        {
            var query = @"SELECT Name FROM Villains WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", villainId);
            string villainName = command.ExecuteScalar() as string;
            return villainName;
        } // Dispose method of connection automatically will be invoked after current code block

        private static int ReadInput()
        {
            var villainId = int.Parse(Console.ReadLine());
            return villainId;
        }
    }
}