using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            for (int c = 0; c < cols; c++)
            {
                var sumColumns = 0;
                for (int r = 0; r < rows; r++)
                {
                    sumColumns += matrix[r, c];
                }

                Console.WriteLine(sumColumns);
            }
        }
    }
}