using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = @"[^\d\.\+\-\*\/\s\,]";
            string digits = @"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)";
            string operation = @"\*|\/";

            var dict = new Dictionary<string, Dictionary<double, double>>();

            List<string> input = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            double monsterHealth = 0;
            double monsterDamage = 0;

            for (int i = 0; i < input.Count; i++)
            {
                MatchCollection matching = Regex.Matches(input[i], letters);
                MatchCollection secondMatching = Regex.Matches(input[i], digits);
                MatchCollection thirdMatching = Regex.Matches(input[i], operation);

                monsterHealth = 0;
                monsterDamage = 0;

                foreach (Match item in matching)
                {
                    monsterHealth += Convert.ToInt32(char.Parse(item.ToString()));
                }

                foreach (Match item in secondMatching)
                {
                    monsterDamage += double.Parse(item.ToString());
                }

                foreach (var item in thirdMatching)
                {
                    if (item.ToString() == "*")
                    {
                        monsterDamage *= 2;
                    }

                    if (item.ToString() == "/")
                    {
                        monsterDamage /= 2;
                    }
                }

                if (!dict.ContainsKey(input[i]))
                {
                    dict[input[i]] = new Dictionary<double, double>();

                    dict[input[i]].Add(monsterHealth, monsterDamage);
                }
            }

            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.Write(kvp.Key + " - ");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.Write($"{kvp2.Key} health, {kvp2.Value:f2} damage");
                }

                Console.WriteLine();
            }
        }
    }
}
