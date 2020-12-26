using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var dict = new Dictionary<string, Dictionary<string, int>>();

            var usersStatistics = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "no more time")
            {
                List<string> inputSplited = input
                    .Split(" -> ")
                    .ToList();

                string username = inputSplited[0];
                string contestName = inputSplited[1];
                int points = int.Parse(inputSplited[2]);

                if (!dict.ContainsKey(contestName))
                {
                    dict[contestName] = new Dictionary<string, int>();
                }

                if (!usersStatistics.ContainsKey(username))
                {
                    usersStatistics[username] = 0;
                }

                if (!dict[contestName].ContainsKey(username))
                {
                    dict[contestName][username] = points;
                    usersStatistics[username] += points;
                }

                if (points > dict[contestName][username])
                {
                    dict[contestName][username] = points;
                    usersStatistics[username] = points;
                }

            }
            
            int counter = 0;
            
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Keys.Count} participants");

                counter = 1;

                foreach (var kvp2 in kvp.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter}. {kvp2.Key} <::> {kvp2.Value}");
                    counter++;
                }
            }

            Console.WriteLine("Individual standings:");
            
            counter = 1;
            
            foreach (var kvp in usersStatistics
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter}. {kvp.Key} -> {kvp.Value}");
                counter++;
            }
        }
    }
}
