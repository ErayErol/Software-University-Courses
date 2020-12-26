using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumberForI = numbers[i];
                bool isNumberTopInteger = true;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int currentNumberForJ = numbers[j];
                    if (currentNumberForI <= currentNumberForJ)
                    {
                        isNumberTopInteger = false;
                        break;
                    }
                }

                if (isNumberTopInteger)
                {
                    Console.Write($"{currentNumberForI} ");
                }
            }
        }
    }
}
