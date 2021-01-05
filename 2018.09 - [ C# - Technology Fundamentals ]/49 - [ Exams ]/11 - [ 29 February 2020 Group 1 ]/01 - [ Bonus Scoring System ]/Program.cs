using System;

namespace BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)


        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            bonus += 5;

            double maxBonus = 0;
            int biggestAttendance = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendanceOfStudent = int.Parse(Console.ReadLine());
                double currBonus = (double)attendanceOfStudent / lecturesCount * bonus;

                if (currBonus > maxBonus)
                {
                    maxBonus = currBonus;
                    biggestAttendance = attendanceOfStudent;
                }

            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {biggestAttendance} lectures.");
        }
    }
}
