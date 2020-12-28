using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendlistMaintenance
{
    class Program
    {
        public static int blacklistedNamesCounter = 0;
        public static int lostNamesCounter = 0;

        static void Main(string[] args)
        {
            List<string> names = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            string input;
            string name = string.Empty;
            int index = 0;
            string newName = string.Empty;

            while ((input = Console.ReadLine()) != "Report")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Blacklist":
                        name = commands[1];

                        BlacklistingUser(names, name);
                        break;
                    case "Error":
                        index = int.Parse(commands[1]);

                        ErrorUser(names, index);
                        break;
                    case "Change":
                        index = int.Parse(commands[1]);
                        newName = commands[2];

                        ChangingUser(names, index, newName);
                        break;
                }
            }

            Console.WriteLine($"Blacklisted names: {blacklistedNamesCounter}");
            Console.WriteLine($"Lost names: {lostNamesCounter}");
            Console.WriteLine(string.Join(" ", names));
        }

        static void BlacklistingUser(List<string> names, string name)
        {
            if (names.Contains(name))
            {
                Console.WriteLine($"{name} was blacklisted.");
                int indexOfTheName = names.IndexOf(name);
                names[indexOfTheName] = "Blacklisted";

                blacklistedNamesCounter++;
            }
            else
            {
                Console.WriteLine($"{name} was not found.");
            }
        }

        static void ErrorUser(List<string> names, int index)
        {
            if (names[index] != "Blacklisted" && names[index] != "Lost")
            {
                Console.WriteLine($"{names[index]} was lost due to an error.");
                names[index] = "Lost";

                lostNamesCounter++;
            }
        }

        static void ChangingUser(List<string> names, int index, string newName)
        {
            if (index >= 0 && index < names.Count)
            {
                Console.WriteLine($"{names[index]} changed his username to {newName}.");
                names[index] = newName;
            }
        }
    }
}
