using System;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int answerStudentPerHour1 = int.Parse(Console.ReadLine());
            int answerStudentPerHour2 = int.Parse(Console.ReadLine());
            int answerStudentPerHour3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int total = answerStudentPerHour1 + answerStudentPerHour2 + answerStudentPerHour3;
            int hour = 0;
            while (studentsCount > 0)
            {
                hour++;
                if (hour % 4 == 0)
                {
                    hour++;
                }
                studentsCount -= total;
            }

            Console.WriteLine($"Time needed: {hour}h.");
        }
    }
}