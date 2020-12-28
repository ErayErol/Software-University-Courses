using System;
using System.Collections.Generic;
using System.Linq;

namespace FroggySquad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogNames = Console
                .ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();

            string[] commands = input
                .Split()
                .ToArray();

            string name = string.Empty;
            int index = 0;
            int count = 0;

            while (commands[0] != "Print")
            {
                switch (commands[0])
                {
                    case "Join":
                        name = commands[1];

                        JoiningFrog(frogNames, name);
                        break;
                    case "Jump":
                        name = commands[1];
                        index = int.Parse(commands[2]);

                        JumpingFrog(frogNames, name, index);
                        break;
                    case "Dive":
                        index = int.Parse(commands[1]);

                        DivingFrog(frogNames, index);
                        break;
                    case "First":
                        count = int.Parse(commands[1]);

                        PrintFirstCountFrogs(frogNames, count);
                        Console.WriteLine();
                        break;
                    case "Last":
                        count = int.Parse(commands[1]);

                        PrintLastCountFrogs(frogNames, count);
                        Console.WriteLine();
                        break;
                }

                input = Console.ReadLine();

                commands = input
                .Split()
                .ToArray();
            }

            if (commands[0] == "Print" && commands[1] == "Normal")
            {
                PrintingNormalFrogs(frogNames);
            }
            else
            {
                PrintingReversedFrogs(frogNames);
            }
        }

        static void JoiningFrog(List<string> frogNames, string name)
        {
            frogNames.Add(name);
        }

        static void JumpingFrog(List<string> frogNames, string name, int index)
        {
            if (index >= 0 && index < frogNames.Count)
            {
                frogNames.Insert(index, name);
            }
        }

        static void DivingFrog(List<string> frogNames, int index)
        {
            if (index >= 0 && index < frogNames.Count)
            {
                frogNames.RemoveAt(index);
            }
        }

        static void PrintFirstCountFrogs(List<string> frogNames, int count)
        {
            if (count > frogNames.Count)
            {
                count = frogNames.Count;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(frogNames[i] + " ");
            }
        }

        static void PrintLastCountFrogs(List<string> frogNames, int count)
        {
            if (count > frogNames.Count)
            {
                count = frogNames.Count;
            }

            for (int i = count; i > 0; i--)
            {
                Console.Write(frogNames[frogNames.Count - i] + " ");
            }
        }

        static void PrintingNormalFrogs(List<string> frogNames)
        {
            Console.WriteLine($"Frogs: {string.Join(" ", frogNames)}");
        }

        static void PrintingReversedFrogs(List<string> frogNames)
        {
            frogNames.Reverse();
            Console.WriteLine($"Frogs: {string.Join(" ", frogNames)}");
        }
    }
}
