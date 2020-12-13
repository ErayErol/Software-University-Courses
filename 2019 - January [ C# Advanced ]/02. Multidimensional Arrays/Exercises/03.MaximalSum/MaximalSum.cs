using System;
using System.Linq;

namespace _03.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] jagged = new int[n[0]][];

            for (int i = 0; i < n[0]; i++)
            {
                jagged[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var biggestSum = int.MinValue;
            var minRow = 0;
            var minCol = 0;

            for (int row = 0; row < n[0] - 2; row++)
            {
                for (int col = 0; col < n[1] - 2; col++)
                {
                    var currentSum = jagged[row][col] + jagged[row][col + 1] + jagged[row][col + 2] +
                                     jagged[row + 1][col] + jagged[row + 1][col + 1] + jagged[row + 1][col + 2] +
                                     jagged[row + 2][col] + jagged[row + 2][col + 1] + jagged[row + 2][col + 2];

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        minRow = row;
                        minCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            for (int row = minRow; row < minRow + 3; row++)
            {
                for (int col = minCol; col < minCol + 3; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}