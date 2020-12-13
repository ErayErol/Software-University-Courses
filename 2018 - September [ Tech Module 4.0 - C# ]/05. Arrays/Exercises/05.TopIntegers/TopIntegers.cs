namespace _05.TopIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TopIntegers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            List<int> result = new List<int>();

            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int e = i + 1; e < numbers.Length; e++)
                {
                    if (numbers[i] > numbers[e])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }

                }

                if (numbers.Length - i - 1 <= count)
                {
                    result.Add(numbers[i]);
                }

                count = 0;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}