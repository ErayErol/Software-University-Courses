using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var dict = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Once upon a time")

            {
                List<string> inputSplited = input
                    .Split(" <:> ")
                    .ToList();

                string dwarfName = inputSplited[0];
                string dwarfHatColor = inputSplited[1];
                int dwarfPhysics = int.Parse(inputSplited[2]);

                string dwarfId = dwarfName + ":" + dwarfHatColor;

                if (!dict.ContainsKey(dwarfId))
                {
                    dict.Add(dwarfId, dwarfPhysics);
                }
                else
                {
                    dict[dwarfId] = Math.Max(dict[dwarfId], dwarfPhysics);
                }
            }

            foreach (var kvp in dict.OrderByDescending(x => x.Value)
                .ThenByDescending(x => dict.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1])
                                             .Count()))
            {
                Console.WriteLine("({0}) {1} <-> {2}",
                 kvp.Key.Split(':')[1],
                 kvp.Key.Split(':')[0],
                 kvp.Value);
            }
        }
    }
}
