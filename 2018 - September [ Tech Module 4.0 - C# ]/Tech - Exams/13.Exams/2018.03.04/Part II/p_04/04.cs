using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, List<string>>();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "Lumpawaroo")
                {
                    break;
                }

                if (commands.Contains(" | "))
                {
                    string[] commandSplitted = commands.Split(" | ");
                    string side = commandSplitted[0];
                    string user = commandSplitted[1];

                    if (dic.Values.Any(x => x.Contains(user)) == false)
                    {
                        if (dic.ContainsKey(side) == false)
                        {
                            dic.Add(side, new List<string>());
                        }
                        dic[side].Add(user);
                    }

                }
                else if (commands.Contains(" -> "))
                {
                    string[] commandSplitted = commands.Split(" -> ");
                    string user = commandSplitted[0];
                    string side = commandSplitted[1];

                    if (dic.Values.Any(x => x.Contains(user)))
                    {
                        if (dic.ContainsKey(side))
                        {
                            dic.Values.Any(x => x.Remove(user));
                        }
                        dic[side].Add(user);
                    }
                    else
                    {
                        if (dic.ContainsKey(side))
                        {
                            dic[side].Add(user);
                        }
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }
        }
    }
}