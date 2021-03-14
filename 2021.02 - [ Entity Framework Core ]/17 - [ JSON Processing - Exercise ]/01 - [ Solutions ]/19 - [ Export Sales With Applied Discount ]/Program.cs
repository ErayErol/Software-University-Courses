namespace IncreaseAgeStoredProc
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Data;

    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            // When we use "using declaration" automatically at the end of the current code block will invoke the method Dispose
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            var id = int.Parse(Console.ReadLine());
                
            // if you want skip this method "CreateProc" and create your procedure directly in your database
            // CreateProc(id, connection);
            // also if you use method "CreateProc" you have to skip method "ExecProc"

            ExecProc(id, connection);
            Print(connection, id);
        } // Dispose method of connection automatically will be invoked after current code block

        private static void Print(SqlConnection connection, int id)
        {
            // If we have nested *using*
            // I use "using statement" instead of "using declaration"
            // Because for me it's more clear when Dispose method will be invoked
            var query = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0] as string;
                        var age = (int)reader[1];
                        Console.WriteLine($"{name} – {age} years old");
                    }
                } // Dispose method of reader automatically will be invoked after current code block
            } // Dispose method of command automatically will be invoked after current code block
        }

        private static void ExecProc(int id, SqlConnection connection)
        {
            string query = @$"EXEC usp_GetOlder {id}";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        } // Dispose method of command automatically will be invoked after current code block

        private static void CreateProc(int id, SqlConnection connection)
        {
            string query = @"CREATE OR ALTER PROC usp_GetOlder @id INT AS UPDATE Minions SET Age += 1 WHERE Id = @id";
            using var command = new SqlCommand(query, connection);
            command.CommandText = "usp_GetOlder";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery(); // This command will EXEC proc usp_GetOlder with given id and you don't need method "ExecProc" from line 46
        } // Dispose method of command automatically will be invoked after current code block
    }
}