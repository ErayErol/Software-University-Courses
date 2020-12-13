using System;
using System.Collections.Generic;
using System.Linq;

namespace Population_Aggregation
{
    public class Population_Aggregation
    {
        public static void Main()
        {
            var countryCityCount = new SortedDictionary<string, int>();
            var cityPopulation = new SortedDictionary<string, long>();

            string prohibitedSymbols = "@#$&0123456789";

            while (true)
            {
                List<string> commands = Console.ReadLine().Split('\\').ToList();

                if (commands[0] == "stop")
                {
                    foreach (var kvp in countryCityCount)
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }

                    foreach (var kvp in cityPopulation.OrderByDescending(c => c.Value).Take(3).ToList())
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }

                    break;
                }

                for (int i = 0; i < commands[0].Length; i++)
                {
                    if (prohibitedSymbols.Contains(commands[0][i]))
                    {
                        commands[0] = commands[0].Replace(commands[0][i].ToString(), "");
                        i--;
                    }
                }

                for (int i = 0; i < commands[1].Length; i++)
                {
                    if (prohibitedSymbols.Contains(commands[1][i]))
                    {
                        commands[1] = commands[1].Replace(commands[1][i].ToString(), "");
                        i--;
                    }
                }

                string country = "";
                string city = "";
                long population = long.Parse(commands[2]);

                if (commands[0][0].ToString() == commands[0][0].ToString().ToUpper())
                {
                    country = commands[0];
                    city = commands[1];
                }
                else
                {
                    city = commands[0];
                    country = commands[1];
                }

                if (countryCityCount.ContainsKey(country) == false)
                {
                    countryCityCount.Add(country, 0);
                }
                countryCityCount[country]++;

                if (cityPopulation.ContainsKey(city) == false)
                {
                    cityPopulation.Add(city, 0);
                }
                cityPopulation[city] = population;
            }
        }
    }
}