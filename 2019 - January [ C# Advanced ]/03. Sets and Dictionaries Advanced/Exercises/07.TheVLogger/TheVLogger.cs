using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _07.TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            var followers = new Dictionary<string, Dictionary<string, int>>();
            var following = new Dictionary<string, Dictionary<string, int>>();
            var joined = new List<string>();

            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Statistics")
                {
                    bool isValid = true;
                    int counter = 1;
                    Console.WriteLine($"The V-Logger has a total of {joined.Count} vloggers in its logs.");
                    foreach (var kvp1 in followers.OrderByDescending(x => x.Value.Values.Count()))
                    {
                        Console.Write($"{counter}. {kvp1.Key} : {kvp1.Value.Values.Count} followers, ");
                        foreach (var kvp2 in following.Where(a => a.Key == kvp1.Key))
                        {
                            Console.WriteLine($"{kvp2.Value.Count} following");
                            if (isValid)
                            {
                                foreach (var kvp3 in kvp1.Value.OrderBy(a => a.Key))
                                {
                                    Console.WriteLine($"*  {kvp3.Key}");
                                }

                                isValid = false;
                            }
                        }

                        counter++;
                    }


                    foreach (var kvp1 in followers.OrderByDescending(x => x.Value.Values.Count()))
                    {
                        foreach (var kvp2 in following.OrderBy(a => a.Value.Values.Count()).OrderByDescending(kvp1.Value => kvp1.Value.Value.Values.Count))
                        {
                            if (kvp1.Key == kvp2.Key)
                            {
                                Console.WriteLine($"{counter++}. {kvp1.Key} : {kvp1.Value.Values.Count} followers, {kvp2.Value.Count} following");
                            }
                        }
                    }


                    break;
                }
                else if (commands[1] == "joined")
                {
                    var joinedName = commands[0];
                    if (joined.Contains(joinedName) == false)
                    {
                        joined.Add(joinedName);
                        followers.Add(joinedName, new Dictionary<string, int>());
                        following.Add(joinedName, new Dictionary<string, int>());
                    }
                }
                else if (commands[1] == "followed")
                {
                    var name1 = commands[0];
                    var name2 = commands[2];

                    if (joined.Contains(name1) && joined.Contains(name2))
                    {
                        if (followers[name2].ContainsKey(name1) == false && name1 != name2)
                        {
                            followers[name2].Add(name1, 0);
                            followers[name2][name1]++;
                            following[name1].Add(name2, 0);
                            following[name1][name2]++;
                        }
                    }
                }
            }
        }
    }
}