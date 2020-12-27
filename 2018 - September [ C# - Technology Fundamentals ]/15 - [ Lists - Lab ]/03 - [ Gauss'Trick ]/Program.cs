using System;
using System.Collections.Generic;
using System.Linq;

namespace GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.
                ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            SumPairsNumbers(numbers);
        }

        static void SumPairsNumbers(List<int> numbers)
        {
            List<int> newNumbers = new List<int>();
            
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                newNumbers.Add(numbers[i] + numbers[numbers.Count - i - 1]);
            }

            if (numbers.Count % 2 == 1)
            {
                newNumbers.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", newNumbers));
        }
    }
}
