using System;
using System.Linq;

namespace _06.BombTheBasement
{
    class BombTheBasement
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[] bomb = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int bombRow = bomb[0];
            int bombCol = bomb[1];
            int radius = bomb[2];

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
            }

            matrix[bombRow][bombCol] = 1;

            for (int row = 1; row < radius; row++)
            {
                for (int col = 1; col < radius; col++)
                {
                    matrix[bombRow - row][bombCol - col] = 1;
                    matrix[bombRow - row][bombCol + col] = 1;
                    matrix[bombRow + row][bombCol - col] = 1;
                    matrix[bombRow + row][bombCol + col] = 1;
                }
            }

            for (int i = 0; i < radius; i++)
            {
                matrix[bombRow + radius - i][bombCol] = 1;
                matrix[bombRow][bombCol + radius - i] = 1;
                matrix[bombRow - radius + i][bombCol] = 1;
                matrix[bombRow][bombCol - radius + i] = 1;
            }

            for (int col = 0; col < cols; col++)
            {
                int counter = 0;
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row][col] == 1)
                    {
                        counter++;
                        matrix[row][col] = 0;
                    }
                }

                for (int i = 0; i < counter; i++)
                {
                    matrix[i][col] = 1;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}