using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
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

            int middle = FindingMiddleIndex(numbers);

            if (FirstPlayerTime(middle, numbers) < SecondPlayerTime(middle, numbers))
            {
                Console.WriteLine($"The winner is left with total time: {FirstPlayerTime(middle, numbers)}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {SecondPlayerTime(middle, numbers)}");
            }
        }

        static int FindingMiddleIndex(List<int> numbers)
        {
            int middleElementIndex = numbers.Count / 2;

            return middleElementIndex;
        }

        static double FirstPlayerTime(int middle, List<int> numbers)
        {
            double firstPlayerTime = 0;

            for (int i = 0; i < middle; i++)
            {
                firstPlayerTime += numbers[i];

                if (numbers[i] == 0)
                {
                    firstPlayerTime *= 0.8;
                }
            }

            return firstPlayerTime;
        }

        static double SecondPlayerTime(int middle, List<int> numbers)
        {
            double secondPlayerTime = 0;

            for (int i = numbers.Count - 1; i > middle; i--)
            {
                secondPlayerTime += numbers[i];

                if (numbers[i] == 0)
                {
                    secondPlayerTime *= 0.8;
                }
            }

            return secondPlayerTime;
        }
    }
}
