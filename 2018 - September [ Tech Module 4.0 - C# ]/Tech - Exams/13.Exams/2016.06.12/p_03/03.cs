using System;
using System.Collections.Generic;
using System.Linq;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamPoints = new SortedDictionary<string, List<int>>();
            var teamGoals = new SortedDictionary<string, List<int>>();

            string key = Console.ReadLine();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "final")
                {
                    Console.WriteLine("League standings:");
                    int index = 1;
                    foreach (var teamPoint in teamPoints.OrderByDescending(t => t.Value.Sum()))
                    {
                        Console.WriteLine($"{index++}. {teamPoint.Key} {string.Join("", teamPoint.Value.Sum())}");
                    }

                    Console.WriteLine("Top 3 scored goals:");
                    foreach (var teamGoal in teamGoals.OrderByDescending(t => t.Value.Sum()).Take(3).ToList())
                    {
                        Console.WriteLine($"- {teamGoal.Key} -> {string.Join("", teamGoal.Value.Sum())}");
                    }

                    break;
                }

                string[] tokens = commands.Split();
                int start = tokens[0].IndexOf(key);
                int finish = tokens[0].LastIndexOf(key);
                char[] reverseHomeTeam = tokens[0].Skip(start + key.Length).Take(finish - start - key.Length).ToArray();
                Array.Reverse(reverseHomeTeam);
                string homeTeam = new string(reverseHomeTeam);
                homeTeam = homeTeam.ToUpper();

                start = tokens[1].IndexOf(key);
                finish = tokens[1].LastIndexOf(key);
                char[] reverseAwayTeam = tokens[1].Skip(start + key.Length).Take(finish - start - key.Length).ToArray();
                Array.Reverse(reverseAwayTeam);
                string awayTeam = new string(reverseAwayTeam);
                awayTeam = awayTeam.ToUpper();

                int[] goals = tokens[2].Split(':').Select(int.Parse).ToArray();
                int homeTeamGoals = goals[0];
                int awayTeamGoals = goals[1];

                int pointsForHomeTeam;
                int pointsForAwayTeam;

                if (homeTeamGoals > awayTeamGoals)
                {
                    pointsForHomeTeam = 3;
                    pointsForAwayTeam = 0;
                }
                else if (awayTeamGoals > homeTeamGoals)
                {
                    pointsForAwayTeam = 3;
                    pointsForHomeTeam = 0;
                }
                else
                {
                    pointsForAwayTeam = 1;
                    pointsForHomeTeam = 1;
                }

                if (teamPoints.ContainsKey(homeTeam) == false)
                {
                    teamPoints.Add(homeTeam, new List<int>());
                    teamGoals.Add(homeTeam, new List<int>());
                }
                teamPoints[homeTeam].Add(pointsForHomeTeam);
                teamGoals[homeTeam].Add(homeTeamGoals);

                if (teamPoints.ContainsKey(awayTeam) == false)
                {
                    teamPoints.Add(awayTeam, new List<int>());
                    teamGoals.Add(awayTeam, new List<int>());
                }
                teamPoints[awayTeam].Add(pointsForAwayTeam);
                teamGoals[awayTeam].Add(awayTeamGoals);
            }
        }
    }
}