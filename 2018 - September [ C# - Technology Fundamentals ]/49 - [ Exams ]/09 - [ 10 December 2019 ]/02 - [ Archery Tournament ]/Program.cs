using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcheryTournament
{
    class Program
    {
        public static int totalPointsCounter = 0;

        static void Main(string[] args)
        {
            List<int> targets = Console
                .ReadLine()
                .Split('|')
                .Select(int.Parse)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Game over")
            {
                string[] commands = input
                    .Split(new string[] { " ", "@" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "Shoot":
                        int startIndex = int.Parse(commands[2]);
                        int length = int.Parse(commands[3]);

                        if (startIndex >= 0 && startIndex <= targets.Count-1)
                        {
                            switch (commands[1])
                            {
                                case "Left":
                                    ShootingToTheLeft(targets, startIndex, length);
                                    break;
                                case "Right":
                                    ShootingToTheRight(targets, startIndex, length);
                                    break;
                            }
                        }
                        break;
                    case "Reverse":
                        ReversingTargets(targets);
                        break;
                }
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {totalPointsCounter} points!");
        }

        static void ShootingToTheLeft(List<int> targets, int startIndex, int length)
        {
            while (length > 0)
            {
                if (startIndex > 0)
                {
                    startIndex--;
                    length--;
                }
                else if (startIndex == 0)
                {
                    startIndex = targets.Count - 1;
                    length--;
                }
            }

            CalculatingThePoints(targets, startIndex);
        }

        static void ShootingToTheRight(List<int> targets, int startIndex, int length)
        {
            while (length > 0)
            {
                if (startIndex < targets.Count - 1)
                {
                    startIndex++;
                    length--;
                }
                else if (startIndex == targets.Count - 1)
                {
                    startIndex = 0;
                    length--;
                }
            }

            CalculatingThePoints(targets, startIndex);
        }

        static void ReversingTargets(List<int> targets)
        {
            targets.Reverse();
        }

        static void CalculatingThePoints(List<int> targets, int startIndex)
        {
            if (targets[startIndex] - 5 >= 0)
            {
                totalPointsCounter += 5;
                targets[startIndex] -= 5;
            }
            else
            {
                totalPointsCounter += targets[startIndex];
                targets[startIndex] = 0;
            }
        }
    }
}
