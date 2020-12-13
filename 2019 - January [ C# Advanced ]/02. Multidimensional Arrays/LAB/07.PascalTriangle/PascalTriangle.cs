using System;

namespace _07.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());
            long[][] triangle = new long[rowSize][];

            for (int row = 0; row < rowSize; row++)
            {
                int col = 0;
                triangle[row] = new long[row + 1];
                triangle[row][col] = 1;

                while (col < row)
                {
                    col++;
                    if (col < row)
                    {
                        triangle[row][col] = triangle[row - 1][col] + triangle[row - 1][col - 1];
                    }
                }

                triangle[row][col] = 1;
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}