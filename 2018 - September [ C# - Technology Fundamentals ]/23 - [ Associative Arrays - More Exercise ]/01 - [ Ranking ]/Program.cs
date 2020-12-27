using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var dict = new Dictionary<string, string>();

            while ((input = Console.ReadLine()) != "end of contests")
            {
                List<string> inputSplited = input
                    .Split(":")
                    .ToList();

                string contestName = inputSplited[0];
                string contestPassword = inputSplited[1];

                if (!dict.ContainsKey(contestName))
                {
                    dict[contestName] = contestPassword;
                }
            }

            var secondDict = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                List<string> inputSplited = input
                   .Split("=>")
                   .ToList();

                string contestName = inputSplited[0];
                string contestPassword = inputSplited[1];
                string username = inputSplited[2];
                int points = int.Parse(inputSplited[3]);

                if (dict.ContainsKey(contestName))
                {
                    if (contestPassword == dict[contestName])
                    {
                        if (!secondDict.ContainsKey(username))
                        {
                            secondDict[username] = new Dictionary<string, int>();
                        }

                        if (!secondDict[username].ContainsKey(contestName))
                        {
                            secondDict[username].Add(contestName, 0);
                        }

                        if (points > secondDict[username][contestName])
                        {
                            secondDict[username][contestName] = points;
                        }
                    }
                }
            }

            var bestCandidate = new Dictionary<string, int>();

            foreach (var item in secondDict)
            {
                bestCandidate[item.Key] = item.Value.Values.Sum();
            }

            string bestCandidateName = bestCandidate.Keys.Max();
            int bestCandidatePoints = bestCandidate.Values.Max();

            foreach (var item in bestCandidate)
            {
                if (item.Value == bestCandidatePoints)
                {
                    Console.WriteLine($"Best candidate is {item.Key} with total {item.Value} points.");
                    break;
                }
            }

            Console.WriteLine("Ranking:");

            foreach (var kvp1 in secondDict.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp1.Key);

                foreach (var kvp2 in kvp1.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  " + kvp2.Key + " -> " + string.Join(" ", kvp2.Value));
                }
            }
        }
    }
}
