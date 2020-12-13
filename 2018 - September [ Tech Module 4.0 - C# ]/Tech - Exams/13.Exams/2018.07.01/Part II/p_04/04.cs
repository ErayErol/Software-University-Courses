using System;
using System.Collections.Generic;
using System.Linq;

namespace p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var userNamePoints = new Dictionary<string, List<int>>();
            var languageCount = new Dictionary<string, int>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split('-');

                if (commands[0] == "exam finished")
                {
                    Console.WriteLine("Results:");
                    foreach (var kvp in userNamePoints.OrderByDescending(u => u.Value.Max()).ThenBy(u => u.Key))
                    {
                        Console.WriteLine($"{kvp.Key} | {string.Join("", kvp.Value.Max())}");
                    }

                    Console.WriteLine("Submissions:");
                    foreach (var kvp in languageCount.OrderByDescending(c => c.Value).ThenBy(n => n.Key))
                    {
                        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }

                    break;
                }

                string name = commands[0];
                string language = commands[1];

                if (language == "banned")
                {
                    if (userNamePoints.ContainsKey(name) == false)
                    {
                        continue;
                    }
                    else
                    {
                        userNamePoints.Remove(name);
                        continue;
                    }
                }

                int currentPoint = int.Parse(commands[2]);
                if (userNamePoints.ContainsKey(name) == false)
                {
                    userNamePoints.Add(name, new List<int>());
                }
                userNamePoints[name].Add(currentPoint);

                if (languageCount.ContainsKey(language) == false)
                {
                    languageCount.Add(language, 0);
                }
                languageCount[language]++;

            }
        }
    }
}