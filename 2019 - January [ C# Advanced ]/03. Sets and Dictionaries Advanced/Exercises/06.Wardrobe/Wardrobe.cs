using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Statistics")
                {
                    Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

                    var sorted = vloggers.OrderByDescending(x => x.Value["followers"].Count)
                                                    .ThenBy(x => x.Value["following"].Count);

                    int count = 1;
                    foreach (var vloger in sorted)
                    {
                        Console.WriteLine($"{count++}. {vloger.Key} : {vloger.Value["followers"].Count} followers, {vloger.Value["following"].Count} following");

                        if (count == 2)
                        {
                            foreach (var followers in vloger.Value["followers"])
                            {
                                Console.WriteLine($"*  {followers}");
                            }
                        }
                    }

                    break;
                }

                var user = commands[0];
                string currCommand = commands[1];
                var targetUser = commands[2];

                if (commands[1] == "joined")
                {
                    if (vloggers.ContainsKey(user) == false)
                    {
                        vloggers.Add(user, new Dictionary<string, SortedSet<string>>());
                        vloggers[user].Add("following", new SortedSet<string>());
                        vloggers[user].Add("followers", new SortedSet<string>());
                    }
                }
                else
                {
                    if (vloggers.ContainsKey(user) && vloggers.ContainsKey(targetUser) && user != targetUser)
                    {
                        vloggers[user]["following"].Add(targetUser);
                        vloggers[targetUser]["followers"].Add(user);
                    }
                }
            }
        }
    }
}