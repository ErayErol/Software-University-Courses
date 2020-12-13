using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var namePoints = new Dictionary<string, int>();
            var languageCounts = new Dictionary<string, int>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split('-');

                if (commands[0] == "exam finished")
                {
                    Console.WriteLine("Results:");
                    foreach (var kvp in namePoints.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
                    {
                        Console.WriteLine($"{kvp.Key} | {kvp.Value}");
                    }

                    Console.WriteLine("Submissions:");
                    foreach (var kvp in languageCounts.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
                    {
                        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }

                    break;
                }

                if (commands.Length == 2)
                {
                    namePoints.Remove(commands[0]);
                    continue;
                }

                string name = commands[0];
                string language = commands[1];
                int point = int.Parse(commands[2]);

                if (namePoints.ContainsKey(name) == false)
                {
                    namePoints[name] = point;
                }
                else
                {
                    if (point > namePoints[name])
                    {
                        namePoints[name] = point;
                    }
                }

                if (languageCounts.ContainsKey(language) == false)
                {
                    languageCounts[language] = 1;
                }
                else
                {
                    languageCounts[language]++;
                }
            }
        }
    }
}