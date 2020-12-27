using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
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

            int length = 1;
            int maxLength = 0;
            
            int start = 0;
            int startOne = 0;

            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    length++;
                }
                else
                {
                    length = 1;
                    start = i;
                }

                if (length > maxLength)
                {
                    maxLength = length;
                    startOne = start;
                }
            }

            for (int i = startOne; i < (startOne + maxLength); i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
