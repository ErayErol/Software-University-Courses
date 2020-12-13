using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!counts.ContainsKey(number))
                {
                    counts.Add(number, 0);
                }

                counts[number]++;
            }

            foreach (var number in counts)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}