using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int dragonsCount = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, List<double>>>();

            for (int i = 0; i < dragonsCount; i++)
            {
                List<string> input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string dragonType = input[0];
                string dragonName = input[1];

                while (input.Contains("null"))
                {
                    int index = input.IndexOf("null");

                    if (index == 2)
                    {
                        input[index] = "45";
                    }
                    else if (index == 3)
                    {
                        input[index] = "250";
                    }
                    else if (index == 4)
                    {
                        input[index] = "10";
                    }
                }

                double dragonDamage = double.Parse(input[2]);
                double dragonHealth = double.Parse(input[3]);
                double dragonArmor = double.Parse(input[4]);

                if (!dict.ContainsKey(dragonType))
                {
                    dict[dragonType] = new Dictionary<string, List<double>>();
                }

                if (!dict[dragonType].ContainsKey(dragonName))
                {
                    dict[dragonType].Add(dragonName, new List<double>());

                    dict[dragonType][dragonName].Add(dragonDamage);
                    dict[dragonType][dragonName].Add(dragonHealth);
                    dict[dragonType][dragonName].Add(dragonArmor);
                }

                if (dict[dragonType].ContainsKey(dragonName))
                {
                    dict[dragonType][dragonName][0] = dragonDamage;
                    dict[dragonType][dragonName][1] = dragonHealth;
                    dict[dragonType][dragonName][2] = dragonArmor;
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}::(" +
                    $"{kvp.Value.Sum(x => x.Value[0]) / kvp.Value.Count:f2}/" +
                    $"{kvp.Value.Sum(x => x.Value[1]) / kvp.Value.Count:f2}/" +
                    $"{kvp.Value.Sum(x => x.Value[2]) / kvp.Value.Count:f2})");

                foreach (var kvp2 in kvp.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{kvp2.Key} -> " +
                        $"damage: {kvp2.Value[0]}, " +
                        $"health: {kvp2.Value[1]}, " +
                        $"armor: {kvp2.Value[2]}");
                }
            }
        }
    }
}
