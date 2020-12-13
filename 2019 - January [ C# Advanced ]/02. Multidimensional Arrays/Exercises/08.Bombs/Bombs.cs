using System;
using System.Linq;

namespace _08.Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var bombs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                var currentBomb = bombs[i].Split(",");
                int bombRow = int.Parse(currentBomb[0]);
                int bombCol = int.Parse(currentBomb[1]);

                if (jagged[bombRow][bombCol] > 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if ((row != bombRow || col != bombCol) && jagged[row][col] > 0)
                            {
                                if ((row == bombRow - 1 || row == bombRow || row == bombRow + 1) &&
                                    (col == bombCol - 1 || col == bombCol || col == bombCol + 1))
                                {
                                    jagged[row][col] -= jagged[bombRow][bombCol];
                                }
                            }
                        }
                    }

                    jagged[bombRow][bombCol] = 0;
                }
            }

            int aliveCells = 0;
            int sum = 0;

            foreach (var row in jagged)
            {
                foreach (var element in row.Where(c => c > 0))
                {
                    sum += element;
                    aliveCells++;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}