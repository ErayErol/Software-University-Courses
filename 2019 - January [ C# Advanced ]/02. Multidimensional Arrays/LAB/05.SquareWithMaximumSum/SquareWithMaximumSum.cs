using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            var biggestSum = int.MinValue;
            var oneTwo = new int[2];
            var threeFour = new int[2];

            for (int c = 0; c < cols - 1; c++)
            {
                for (int r = 0; r < rows - 1; r++)
                {
                    var one = matrix[r, c];
                    var two = matrix[r, c + 1];
                    var three = matrix[r + 1, c];
                    var four = matrix[r + 1, c + 1];

                    var currentSum = one + two + three + four;

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        oneTwo[0] = one;
                        oneTwo[1] = two;
                        threeFour[0] = three;
                        threeFour[1] = four;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", oneTwo));
            Console.WriteLine(string.Join(" ", threeFour));
            Console.WriteLine(biggestSum);
        }
    }
}