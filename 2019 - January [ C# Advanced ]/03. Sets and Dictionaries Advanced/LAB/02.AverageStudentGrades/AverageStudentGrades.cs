using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();
            var input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                var student = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = student[0];
                double grade = double.Parse(student[1]);

                if (students.ContainsKey(name) == false)
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }

            foreach (var pair in students)
            {
                var name = pair.Key;
                var studentGrades = pair.Value;
                var average = studentGrades.Average();

                Console.WriteLine($"{name} -> {string.Join(" ", studentGrades.Select(x => string.Format($"{x:F2}")))} (avg: {average:F2})");
            }
        }
    }
}