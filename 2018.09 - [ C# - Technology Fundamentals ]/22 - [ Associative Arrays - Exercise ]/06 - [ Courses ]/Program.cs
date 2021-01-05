using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> courseArgs = input
                    .Split(" : ")
                    .ToList();

                string courseName = courseArgs[0];
                string studentName = courseArgs[1];

                if (!dict.ContainsKey(courseName))
                {
                    dict[courseName] = new List<string>();
                }

                dict[courseName].Add(studentName);
            }

            foreach (var item in dict.OrderByDescending(x => x.Value.Count()))
            {
                string courseName = item.Key;
                int studsCount = item.Value.Count();

                Console.WriteLine($"{courseName}: {studsCount}");

                foreach (var studs in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {studs}");
                }
            }
        }
    }
}
