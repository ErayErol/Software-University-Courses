using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var dict = new Dictionary<string, List<int>>();

            var submissionsCount = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                List<string> userInfo = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string userName = userInfo[0];
                string userLanguage = userInfo[1];

                if (userLanguage == "banned")
                {
                    dict.Remove(userName);
                }
                else
                {
                    int userPoints = int.Parse(userInfo[2]);

                    if (!dict.ContainsKey(userName))
                    {
                        dict[userName] = new List<int>();
                    }

                    dict[userName].Add(userPoints);

                    if (!submissionsCount.ContainsKey(userLanguage))
                    {
                        submissionsCount[userLanguage] = 0;
                    }

                    submissionsCount[userLanguage]++;
                }
            }

            Console.WriteLine("Results:");

            foreach (var item in dict.OrderByDescending(x => x.Value.Max())
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " | " + item.Value.Max());
            }

            Console.WriteLine("Submissions:");

            foreach (var item in submissionsCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
