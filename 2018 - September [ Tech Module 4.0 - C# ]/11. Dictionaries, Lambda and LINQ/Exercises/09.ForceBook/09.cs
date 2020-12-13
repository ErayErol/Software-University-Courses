using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var sideName = new Dictionary<string, string>();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "Lumpawaroo")
                {
                    break;
                }

                string[] tokens = new string[0];

                if (commands.Contains("|"))
                {
                    tokens = commands.Split(" | ");

                    string side = tokens[0];
                    string name = tokens[1];

                    if (!sideName.ContainsKey(name))
                    {
                        sideName[name] = side;
                    }
                }
                else
                {
                    tokens = commands.Split(" -> ");

                    string name = tokens[0];
                    string side = tokens[1];

                    sideName[name] = side;

                    Console.WriteLine($"{name} joins the {side} side!");
                }
            }

            var filtredNameSide = sideName
                .GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key);

            foreach (var kvp in filtredNameSide)
            {
                string side = kvp.Key;
                var nameSide = kvp;

                Console.WriteLine($"Side: {side}, Members: {nameSide.Count()}");

                foreach (var kvpValue in nameSide.OrderBy(x => x.Key))
                {
                    string name = kvpValue.Key;

                    Console.WriteLine($"! {name}");
                }
            }
        }
    }
}