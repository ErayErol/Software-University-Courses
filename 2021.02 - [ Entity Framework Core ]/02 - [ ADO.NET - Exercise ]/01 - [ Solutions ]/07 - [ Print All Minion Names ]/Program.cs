using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace PrintAllMinionNames
{
    class Program
    {
        private const string SqlConnectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

        static void Main(string[] args)
        {
            // When we use "using declaration" automatically at the end of the current code block will invoke the method Dispose
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();
            var minionNames = Names(connection);
            Print(minionNames);
        } // Dispose method of connection automatically will be invoked after current code block

        private static void Print(List<string> names)
        {
            for (int i = 1; i <= Math.Ceiling(names.Count / 2.0); i++)
            {
                Console.WriteLine(names[i - 1]);

                if (i == names.Count / 2 + 1 && names.Count % 2 == 1)
                {
                    continue;
                }

                Console.WriteLine(names[^i]);
            }
        }

        private static List<string> Names(SqlConnection connection)
        {
            // If we have nested *using*
            // I use "using statement" instead of "using declaration"
            // Because for me it's more clear when Dispose method will be invoked
            var query = @"SELECT Name FROM Minions";
            using (var sqlCommand = new SqlCommand(query, connection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var names = new List<string>();
                    while (reader.Read())
                    {
                        var name = reader[0] as string;
                        names.Add(name);
                    }

                    return names;
                }
            }
        }
    }
}