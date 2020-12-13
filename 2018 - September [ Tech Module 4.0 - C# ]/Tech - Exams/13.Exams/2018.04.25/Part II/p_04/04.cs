using System;
using System.Collections.Generic;
using System.Linq;

namespace p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerPositionSkills = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" -> ");

                if (commands[0] == "Season end")
                {
                    foreach (var kvp in playerPositionSkills.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(p => p.Key))
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");
                        foreach (var positionSkills in kvp.Value.OrderByDescending(s => s.Value).ThenBy(p => p.Key))
                        {
                            Console.WriteLine($"- {positionSkills.Key} <::> {positionSkills.Value}");
                        }
                    }

                    break;
                }

                if (commands[0].Contains("vs"))
                {
                    string[] command = commands[0].Split();

                    string firstPlayerName = command[0];
                    string secondPlayerName = command[2];

                    if (playerPositionSkills.ContainsKey(firstPlayerName) && playerPositionSkills.ContainsKey(secondPlayerName))
                    {
                        List<string> firstPlayerPositions = new List<string>(playerPositionSkills[firstPlayerName].Keys);
                        List<string> secondPlayerPositions = new List<string>(playerPositionSkills[secondPlayerName].Keys);

                        int minLength = 0;
                        int maxLength = 0;
                        List<string> min = new List<string>();
                        List<string> max = new List<string>();

                        string minName = "";
                        string maxName = "";

                        if (firstPlayerPositions.Count > secondPlayerPositions.Count)
                        {
                            minLength = secondPlayerPositions.Count;
                            maxLength = firstPlayerPositions.Count;
                            min = secondPlayerPositions;
                            max = firstPlayerPositions;
                            minName = secondPlayerName;
                            maxName = firstPlayerName;
                        }
                        else
                        {
                            minLength = firstPlayerPositions.Count;
                            maxLength = secondPlayerPositions.Count;
                            min = firstPlayerPositions;
                            max = secondPlayerPositions;
                            minName = firstPlayerName;
                            maxName = secondPlayerName;
                        }

                        bool isValid = false;

                        for (int i = 0; i < minLength; i++)
                        {
                            for (int e = 0; e < maxLength; e++)
                            {
                                if (min[i] == max[e])
                                {
                                    if (playerPositionSkills[minName][min[i]] > playerPositionSkills[maxName][max[e]])
                                    {
                                        playerPositionSkills.Remove(maxName);
                                        isValid = true;
                                        break;
                                    }
                                    else if (playerPositionSkills[maxName][max[e]] > playerPositionSkills[minName][min[i]])
                                    {
                                        playerPositionSkills.Remove(minName);
                                        isValid = true;
                                        break;
                                    }
                                }
                            }

                            if (isValid)
                            {
                                break;
                            }
                        }
                    }

                    continue;
                }

                string player = commands[0];
                string position = commands[1];
                int currentSkills = int.Parse(commands[2]);

                if (playerPositionSkills.ContainsKey(player) == false)
                {
                    playerPositionSkills.Add(player, new Dictionary<string, int>());
                }

                if (playerPositionSkills[player].ContainsKey(position) == false)
                {
                    playerPositionSkills[player].Add(position, currentSkills);
                }
                else
                {
                    if (currentSkills > playerPositionSkills[player][position])
                    {
                        playerPositionSkills[player][position] = currentSkills;
                    }
                }
            }
        }
    }
}