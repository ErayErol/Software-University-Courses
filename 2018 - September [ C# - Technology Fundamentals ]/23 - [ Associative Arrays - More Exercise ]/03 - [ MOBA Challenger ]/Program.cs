using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var dict = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "Season end")
            {
                List<string> inputSplited = input
                    .Split()
                    .ToList();

                if (inputSplited[1] == "->")
                {
                    inputSplited = input.Split(" -> ").ToList();

                    string playerName = inputSplited[0];
                    string playerPosition = inputSplited[1];
                    int playerSkill = int.Parse(inputSplited[2]);

                    if (!dict.ContainsKey(playerName))
                    {
                        dict[playerName] = new Dictionary<string, int>();
                    }

                    if (!dict[playerName].ContainsKey(playerPosition))
                    {
                        dict[playerName].Add(playerPosition, playerSkill);
                    }

                    if (dict[playerName][playerPosition] < playerSkill && dict[playerName].ContainsKey(playerPosition))
                    {
                        dict[playerName][playerPosition] += playerSkill;
                    }
                }
                else if (inputSplited[1] == "vs")
                {
                    inputSplited = input.Split(" vs ").ToList();

                    string firstPlayerName = inputSplited[0];
                    string secondPlayerName = inputSplited[1];

                    if (dict.ContainsKey(firstPlayerName) && dict.ContainsKey(secondPlayerName))
                    {
                        bool isTheyHaveCommonPositions = false;

                        foreach (var kvp in dict[firstPlayerName])
                        {
                            foreach (var kvp2 in dict[secondPlayerName])
                            {
                                if (kvp.Key == kvp2.Key)
                                {
                                    isTheyHaveCommonPositions = true;
                                    break;
                                }
                            }

                            if (isTheyHaveCommonPositions)
                            {
                                break;
                            }
                        }

                        if (isTheyHaveCommonPositions)
                        {
                            if (dict[firstPlayerName].Values.Sum() > dict[secondPlayerName].Values.Sum())
                            {
                                dict.Remove(secondPlayerName);
                            }
                            else if (dict[firstPlayerName].Values.Sum() < dict[secondPlayerName].Values.Sum())
                            {
                                dict.Remove(firstPlayerName);
                            }
                        }
                    }
                }
            }

            foreach (var kvp in dict
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");

                foreach (var kvp2 in kvp.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {kvp2.Key} <::> {string.Join("", kvp2.Value)}");
                }
            }
        }
    }
}
