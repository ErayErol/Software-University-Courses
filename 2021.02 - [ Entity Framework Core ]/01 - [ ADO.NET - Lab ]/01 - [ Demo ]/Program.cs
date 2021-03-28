namespace Demo
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Data;

    class Program
    {
        private const string MyLastSqlExamDate = "13.02.2021";

        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=Bitbucket"))
            {
                connection.Open();
                SqlCommand sqlCommand = null;
                Console.WriteLine($"All exercises with select statement from my last SQL Exam - {MyLastSqlExamDate}");
                Exercise(connection, sqlCommand, 5, Query.StatementSelectExercise5);
                Exercise(connection, sqlCommand, 6, Query.StatementSelectExercise6);
                Exercise(connection, sqlCommand, 7, Query.StatementSelectExercise7);
                Exercise(connection, sqlCommand, 8, Query.StatementSelectExercise8);
                Exercise(connection, sqlCommand, 9, Query.StatementSelectExercise9);
                Exercise(connection, sqlCommand, 10, Query.StatementSelectExercise10);
                Exercise11(connection, sqlCommand, 11, Query.CreateFunctionExercise11, Query.StatementSelectExercise11);
                Exercise12(connection, sqlCommand, 12, Query.CreateProcedureExercise12, Query.StatementSelectExercise12);
            }
        }

        private static void ExercisesNumber(int exerciseNumber)
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"Exercise {exerciseNumber}");
        }

        private static void Exercise(SqlConnection connection, SqlCommand sqlCommand, int exerciseNumber, string query)
        {
            ExercisesNumber(exerciseNumber);
            sqlCommand = new SqlCommand(query, connection);
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var record = (IDataRecord)reader;
                    for (int i = 0; i < record.FieldCount - 1; i++)
                    {
                        Console.Write(record.GetValue(i) + " - ");
                    }

                    var lastRecordValue = record.GetValue(record.FieldCount - 1);
                    Console.WriteLine(lastRecordValue);
                }
            }
        }

        private static void Exercise11(SqlConnection connection, SqlCommand sqlCommand, int exerciseNumber, string createQuery, string selectQuery)
        {
            ExercisesNumber(exerciseNumber);
            sqlCommand = new SqlCommand(createQuery, connection);
            using (var reader = sqlCommand.ExecuteReader())
            {
            }

            sqlCommand = new SqlCommand(selectQuery, connection);
            var allUserCommits = sqlCommand.ExecuteScalar();
            Console.WriteLine(allUserCommits);
            sqlCommand.Dispose();
        }

        private static void Exercise12(SqlConnection connection, SqlCommand sqlCommand, int exerciseNumber, string createQuery, string selectQuery)
        {
            ExercisesNumber(exerciseNumber);
            sqlCommand = new SqlCommand(createQuery, connection);
            using (var reader = sqlCommand.ExecuteReader())
            {
            }

            sqlCommand = new SqlCommand(selectQuery, connection);
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