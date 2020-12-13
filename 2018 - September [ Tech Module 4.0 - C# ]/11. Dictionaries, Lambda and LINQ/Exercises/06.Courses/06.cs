using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] course = Console.ReadLine().Split(new string[] { " : " }, StringSplitOptions.RemoveEmptyEntries);

                if (course[0] == "end")
                {
                    break;
                }

                string courseName = course[0];
                string studentName = course[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);
            }

            foreach (var kvp in courses.OrderByDescending(v => v.Value.Count)) // подреждане на ключове - OrderByDescending -> от голямо към малко
            {
                string currentCourse = kvp.Key;
                int sumOfContestants = kvp.Value.Count;

                Console.WriteLine($"{currentCourse}: {sumOfContestants}"); 

                foreach (var studentName in kvp.Value.OrderBy(s => s)) // подреждане на участници в листа - OrderBy -> от малко към голямо
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}