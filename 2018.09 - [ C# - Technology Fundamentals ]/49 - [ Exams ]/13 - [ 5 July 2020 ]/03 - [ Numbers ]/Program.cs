using System;
using System.Collections.Generic;
using System.Linq;

namespace midExamSundayFundamentalsNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers.Sort();
            numbers.Reverse();

            Calculatings(numbers);

            if (numbers.Count > 5)
            {
                numbers.RemoveRange(5, numbers.Count - 5);
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

        }

        static void Calculatings(List<int> numbers)
        {
            double averageValue = numbers.Sum() * 1.0 / numbers.Count * 1.0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= averageValue)
                {
                    numbers.RemoveAt(i);
                    i = -1;
                }
            }
        }
    }
}
