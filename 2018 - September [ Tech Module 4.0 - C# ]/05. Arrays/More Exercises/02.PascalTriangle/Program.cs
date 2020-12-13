using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Int32.Parse(Console.ReadLine());

            int[][] pascalTriangle = new int[count][];

            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                pascalTriangle[i] = new int[i + 1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][i] = 1;
            }

            for (int i = 2; i < pascalTriangle.Length; i++)
            {
                for (int j = 0; j < pascalTriangle[i].Length - 2; j++)
                {
                    pascalTriangle[i][j + 1] = pascalTriangle[i - 1][j] + pascalTriangle[i - 1][j + 1];
                }
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}