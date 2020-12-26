using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());

            string firstRegex = @"[sStTaArR]";
            string secondRegex = @"@(?<planetName>[A-Za-z]+)[^@!:>-]*?:[^@!:>-]*?(?<planetPopulation>\d+)[^@!:>-]*?![^@!:>-]*?(?<attackType>[AD])![^@!:>-]*?->[^@!:>-]*?(?<soldierCount>\d+)";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < messagesCount; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matching = Regex.Matches(input, firstRegex);

                string message = string.Empty;
                for (int j = 0; j < input.Length; j++)
                {
                    message += (char)(input[j] - matching.Count);
                }

                Match secondMatching = Regex.Match(message, secondRegex);

                if (secondMatching.Success)
                {
                    string planetName = secondMatching.Groups["planetName"].Value;
                    int planetPopulation = int.Parse(secondMatching.Groups["planetPopulation"].Value);
                    string attackType = secondMatching.Groups["attackType"].Value;
                    int soldierCount = int.Parse(secondMatching.Groups["soldierCount"].Value);

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var item in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var item in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
