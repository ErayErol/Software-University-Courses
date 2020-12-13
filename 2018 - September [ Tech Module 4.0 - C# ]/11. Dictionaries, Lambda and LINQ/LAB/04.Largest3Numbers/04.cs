using System;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] sorted = numbers.OrderByDescending(n => n).ToArray();

            int length = sorted.Length;
            if (length > 3)
            {
                length = 3;
            }

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{sorted[i]} ");
            }

            Console.WriteLine();
        }
    }
}