namespace _03.Miner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Miner
    {
        static string[][] jagged;
        static int rows;
        static int leftCoals;

        static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            jagged = new String[rows][];
            var directions = new Queue<string>(Console.ReadLine().Split());
            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split();
            }

            while (true)
            {
                if (HaveCoals() == false)
                {
                    if (directions.Any() == false)
                    {
                        foreach (var row in jagged.Where(x => x.Contains("c")))
                        {
                            leftCoals++;
                        }
                        Result();
                    }
                    var currDirection = directions.Dequeue();
                    IsInFieldOrDead(currDirection);
                }
                else
                {
                    Result();
                }
            }
        }

        private static void Result()
        {
            for (int row = 0; row < rows; row++)
            {
                if (jagged[row].Contains("s"))
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        if (jagged[row][col] == "s")
                        {
                            if (leftCoals == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({row}, {col})");
                            }
                            else
                            {
                                Console.WriteLine($"{leftCoals} coals left. ({row}, {col})");
                            }

                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        private static bool HaveCoals()
        {
            foreach (var row in jagged.Where(x => x.Contains("c")))
            {
                return false;
            }

            return true;
        }

        private static void IsInFieldOrDead(string currDirection)
        {
            for (int row = 0; row < rows; row++)
            {
                if (jagged[row].Contains("s"))
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        if (jagged[row][col] == "s")
                        {
                            switch (currDirection)
                            {
                                case "up": if (IsInField(row - 1, col)) jagged[row][col] = "*"; break;
                                case "down": if (IsInField(row + 1, col)) jagged[row][col] = "*"; break;
                                case "right": if (IsInField(row, col + 1)) jagged[row][col] = "*"; break;
                                case "left": if (IsInField(row, col - 1)) jagged[row][col] = "*"; break;
                            }
                            return;
                        }
                    }
                }
            }
        }

        private static bool IsInField(int row, int col)
        {
            if (row >= 0 && row < rows && col >= 0 && col < rows)
            {
                if (jagged[row][col] == "e")
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    Environment.Exit(0);
                }

                jagged[row][col] = "s";
                return true;
            }

            return false;
        }
    }
}