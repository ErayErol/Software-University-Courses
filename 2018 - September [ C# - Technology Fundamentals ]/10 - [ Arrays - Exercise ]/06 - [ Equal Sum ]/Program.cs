using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.
                ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int leftSumOfTheNumbers = 0;
            int rightSumOfTheNumbers = numbers.Sum();

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSumOfTheNumbers -= numbers[i];

                if (leftSumOfTheNumbers == rightSumOfTheNumbers)
                {
                    Console.WriteLine(i);
                    return;
                }

                leftSumOfTheNumbers += numbers[i];
            }

            Console.WriteLine("no");
        }
    }
}
