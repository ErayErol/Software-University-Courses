using System;
using System.Linq;

namespace _09.Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var jagged = new string[n][];

            var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            int[] coal = new[] { 0 };
            int[] lastRowAndCol = new[] { 0, 0 };

            for (int i = 0; i < commands.Length; i++)
            {
                bool isValid = false;
                string direction = commands[i];
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (jagged[row][col] == "s")
                        {
                            if (direction == "up" && row - 1 >= 0)
                            {
                                Character(jagged[row - 1][col], coal, row - 1, col, jagged, row, col, lastRowAndCol);
                            }
                            else if (direction == "down" && row + 1 < n)
                            {
                                Character(jagged[row + 1][col], coal, row + 1, col, jagged, row, col, lastRowAndCol);
                            }
                            else if (direction == "left" && col - 1 >= 0)
                            {
                                Character(jagged[row][col - 1], coal, row, col - 1, jagged, row, col, lastRowAndCol);
                            }
                            else if (direction == "right" && col + 1 < n)
                            {
                                Character(jagged[row][col + 1], coal, row, col + 1, jagged, row, col, lastRowAndCol);
                            }

                            isValid = true;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        break;
                    }
                }
            }

            int coalsLeft = 0;
            foreach (var r in jagged)
            {
                foreach (var element in r.Where(c => c == "c"))
                {
                    coalsLeft++;
                }
            }

            Console.WriteLine($"{coalsLeft} coals left. ({lastRowAndCol[0]}, {lastRowAndCol[1]})");
        }

        static void Character(string symbol, int[] coal, int currentRow, int currentCol, 
                              string[][] jagged, int jaggedRow, int jaggedCol, int[] lastRowAndCol)
        {
            lastRowAndCol[0] = currentRow;
            lastRowAndCol[1] = currentCol;

            switch (symbol)
            {
                case "*":
                    jagged[currentRow][currentCol] = "s";
                    jagged[jaggedRow][jaggedCol] = "*";
                    break;

                case "e":
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    Environment.Exit(0);
                    break;

                case "c":
                    jagged[currentRow][currentCol] = "s";
                    jagged[jaggedRow][jaggedCol] = "*";

                    bool isCollectedAll = true;
                    foreach (var r in jagged)
                    {
                        foreach (var element in r.Where(c => c == "c"))
                        {
                            isCollectedAll = false;
                            break;
                        }
                    }

                    if (isCollectedAll)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        Environment.Exit(0);
                    }

                    coal[0]++;
                    break;
            }
        }
    }
}