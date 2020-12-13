using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            char[][] jagged = new char[input[0]][];

            for (int i = 0; i < input[0]; i++)
            {
                jagged[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            int counter = 0;
            for (int row = 0; row < input[0] - 1; row++)
            {
                for (int col = 0; col < input[1] - 1; col++)
                {
                    if (jagged[row][col] == jagged[row + 1][col] &&
                        jagged[row][col] == jagged[row][col + 1] &&
                        jagged[row][col] == jagged[row + 1][col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}