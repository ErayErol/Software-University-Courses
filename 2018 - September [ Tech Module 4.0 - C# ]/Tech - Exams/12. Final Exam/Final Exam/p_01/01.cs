using System;
using System.Collections.Generic;
using System.Linq;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var play = new Dictionary<string, long>();
            var add = new Dictionary<string, List<string>>();
            long totalSum = 0;

            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "start of concert")
                {
                    Console.WriteLine($"Total time: {totalSum}");
                    foreach (var kvp in play.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }

                    string name = Console.ReadLine();
                    foreach (var kvp in add.Where(x => x.Key == name))
                    {
                        Console.WriteLine($"{kvp.Key}");
                        for (int i = 0; i < kvp.Value.Count; i++)
                        {
                            Console.WriteLine($"=> {kvp.Value[i]}");
                        }
                    }

                    break;
                }

                string[] firstSplitted = commands.Split("; ");
                if (firstSplitted[0] == "Play")
                {
                    string bandName = firstSplitted[1];
                    long currentTime = long.Parse(firstSplitted[2]);

                    if (play.ContainsKey(bandName) == false)
                    {
                        play.Add(bandName, 0);
                    }

                    play[bandName] += currentTime;
                    totalSum += currentTime;
                }
                else if (firstSplitted[0] == "Add")
                {
                    string bandName = firstSplitted[1];

                    if (add.ContainsKey(bandName) == false)
                    {
                        add.Add(bandName, new List<string>());
                    }

                    string[] membersSplitted = firstSplitted[2].Split(", ");

                    for (int i = 0; i < membersSplitted.Length; i++)
                    {
                        if (add[bandName].Contains(membersSplitted[i]) == false)
                        {
                            add[bandName].Add(membersSplitted[i]);
                        }
                    }
                }
            }  
        }
    }
}