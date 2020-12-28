using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console
                .ReadLine()
                .Split("|")
                .ToList();

            string input;

            List<string> loot = new List<string>();
            List<string> newChest = new List<string>();

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Loot":
                        loot.Clear();
                        loot.AddRange(commands);

                        Looting(chest, loot);
                        break;
                    case "Drop":
                        int index = int.Parse(commands[1]);

                        Dropping(chest, index);
                        break;
                    case "Steal":
                        int count = int.Parse(commands[1]);

                        Stealing(chest, count, newChest);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", newChest));

            if (chest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {CalculatingAverageTreasureGain(chest):f2} pirate credits.");
            }
        }

        static void Looting(List<string> chest, List<string> loot)
        {
            for (int i = 1; i < loot.Count; i++)
            {
                if (!chest.Contains(loot[i]))
                {
                    chest.Insert(0, loot[i]);
                }
            }
        }

        static void Dropping(List<string> chest, int index)
        {
            if (index >= 0 && index < chest.Count)
            {
                string temp = chest[index];
                chest.Remove(chest[index]);
                chest.Add(temp);
            }
        }

        static void Stealing(List<string> chest, int count, List<string> newChest)
        {

            if (count > chest.Count)
            {
                count = chest.Count;
            }

            for (int i = 0; i < count; i++)
            {
                newChest.Add(chest[chest.Count - 1]);
                chest.Remove(chest[chest.Count - 1]);
            }

            newChest.Reverse();
        }

        static double CalculatingAverageTreasureGain(List<string> chest)
        {
            double result = 0;

            for (int i = 0; i < chest.Count; i++)
            {
                result += chest[i].Count();
            }

            result /= chest.Count();

            return result;
        }
    }
}
