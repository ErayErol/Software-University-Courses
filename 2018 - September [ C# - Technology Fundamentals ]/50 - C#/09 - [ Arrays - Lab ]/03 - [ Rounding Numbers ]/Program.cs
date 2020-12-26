using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console
                .ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (double values in numbers)
            {
                int numbersRounding = (int)Math.Round(values, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{values} => {numbersRounding}");
            }
        }
    }
}
