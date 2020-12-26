using System;
using System.Numerics;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());

            long[][] arr = new long[height][];
            arr[0] = new long[1];
            arr[0][0] = 1;

            for (long i = 1; i < arr.Length; i++)
            {
                arr[i] = new long[i + 1];
                arr[i][0] = 1;
                arr[i][arr[i].Length - 1] = 1;

                for (long j = 1; j < arr[i].Length - 1; j++)
                {
                    long l = arr[i - 1][j - 1];
                    long r = arr[i - 1][j];

                    arr[i][j] = l + r;
                }
            }

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(string.Join(" ", arr[i]));
            }
        }
    }
}
