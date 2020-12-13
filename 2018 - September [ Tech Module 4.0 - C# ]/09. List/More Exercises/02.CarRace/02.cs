using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            double leftCarTime = 0;
            double rightCarTime = 0;

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                if (numbers[i] == 0)
                {
                    leftCarTime *= 0.8;
                    continue;
                }

                leftCarTime += numbers[i];
            }

            for (int i = numbers.Count - 1; i > numbers.Count / 2; i--)
            {
                if (numbers[i] == 0)
                {
                    rightCarTime *= 0.8;
                    continue;
                }

                rightCarTime += numbers[i];
            }

            if (leftCarTime <= rightCarTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftCarTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightCarTime}");
            }
        }
    }
}