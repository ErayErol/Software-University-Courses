using System;
using System.Collections.Generic;
using System.Linq;

namespace p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var meTube = new Dictionary<string, KeyValuePair<int, int>>();

            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "stats time")
                {
                    commands = Console.ReadLine();
                    if (commands == "by likes")
                    {
                        foreach (var kvp in meTube.OrderByDescending(v => v.Value.Value))
                        {
                            Console.WriteLine($"{kvp.Key} - {kvp.Value.Key} views - {kvp.Value.Value} likes");
                        }
                    }
                    else if (commands == "by views")
                    {
                        foreach (var kvp in meTube.OrderByDescending(v => v.Value.Key))
                        {
                            Console.WriteLine($"{kvp.Key} - {kvp.Value.Key} views - {kvp.Value.Value} likes");
                        }
                    }

                    Environment.Exit(0);
                }

                KeyValuePair<int, int> add = new KeyValuePair<int, int>(0, 0);
                string name = "";

                string[] splittedCommand = new[] { commands };
                if (commands.Contains('-'))
                {
                    splittedCommand = commands.Split('-');

                    name = splittedCommand[0];
                    int views = int.Parse(splittedCommand[1]);

                    if (meTube.ContainsKey(name) == false)
                    {
                        meTube.Add(name, new KeyValuePair<int, int>());
                        add = new KeyValuePair<int, int>(views, 0);
                    }
                    else
                    {
                        add = new KeyValuePair<int, int>(meTube[name].Key + views, meTube[name].Value);
                    }
                }
                else if (commands.Contains(':'))
                {
                    splittedCommand = commands.Split(':');

                    string rate = splittedCommand[0];
                    name = splittedCommand[1];
                    int likes = 0;

                    if (meTube.ContainsKey(name) == false)
                    {
                        continue;
                    }

                    if (rate == "like")
                    {
                        likes++;
                    }
                    else if (rate == "dislike")
                    {
                        likes--;
                    }

                    add = new KeyValuePair<int, int>(meTube[name].Key, meTube[name].Value + likes);
                }

                meTube[name] = add;
            }
        }
    }
}