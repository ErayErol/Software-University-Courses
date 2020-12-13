using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(grade);
            }

            students = students
                .Where(g => g.Value.Average() >= 4.50). // презаписване на речникът където Average на стойността(оценките) му е по-голяма или равна на 4.50
                OrderByDescending(g => g.Value.Average()). // подреждане на стойността(оценките) на речникът по Average от голямо към малко
                ToDictionary(k => k.Key, v => v.Value); 

            foreach (var student in students) 
            {
                string name = student.Key;
                double grade = student.Value.Average();

                Console.WriteLine($"{name} -> {grade:F2}");
            }
        }
    }
}