using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var dict = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] inputArgs = input
                        .Split(" | ");

                    string userName = inputArgs[1];
                    string side = inputArgs[0];

                    if (!dict.ContainsKey(userName))
                    {
                        dict[side] = new List<string>();
                    }

                    bool isMemberExisting = false;

                    foreach (var item in dict)
                    {
                        if (item.Value.Contains(userName))
                        {
                            isMemberExisting = true;
                            break;
                        }
                    }

                    if (!isMemberExisting)
                    {
                        dict[side].Add(userName);
                    }
                }
                else
                {
                    string[] inputArgs = input
                        .Split(" -> ");

                    string userName = inputArgs[0];
                    string side = inputArgs[1];

                    bool isMemberExisting = false;
                    string currSide = string.Empty;

                    foreach (var item in dict)
                    {
                        if (item.Value.Contains(userName))
                        {
                            isMemberExisting = true;
                            currSide = item.Key;
                            break;
                        }
                    }

                    if (isMemberExisting)
                    {
                        dict[currSide].Remove(userName);
                    }

                    if (!dict.ContainsKey(side))
                    {
                        dict[side] = new List<string>();
                    }

                    dict[side].Add(userName);
                    Console.WriteLine($"{userName} joins the {side} side!");
                }
            }

            dict = dict
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in dict)
            {
                string sideName = item.Key;
                List<string> users = item.Value;

                users.Sort();

                Console.WriteLine($"Side: {sideName}, Members: {users.Count}");

                foreach (var values in users)
                {
                    Console.WriteLine($"! {values}");
                }
            }
        }
    }
}
