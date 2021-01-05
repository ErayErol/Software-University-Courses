using System;
using System.Collections.Generic;
using System.Linq;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();

            while (true)
            {
                string oreName = Console.ReadLine();

                if (oreName == "stop")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, dict.Select(x => $"{x.Key} -> {x.Value}")));
                    break;
                }

                int oreCount = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(oreName))
                {
                    dict[oreName] = oreCount;
                }
                else
                {
                    dict[oreName] += oreCount;
                }
            }
        }
    }
}
