using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> lastTwoValues = new List<int>();

            if (firstNumbers.Count > secondNumbers.Count)
            {
                lastTwoValues.Add(firstNumbers[firstNumbers.Count - 1]);
                lastTwoValues.Add(firstNumbers[firstNumbers.Count - 2]);

                firstNumbers.RemoveAt(firstNumbers.Count - 1);
                firstNumbers.RemoveAt(firstNumbers.Count - 1);
            }
            else
            {
                lastTwoValues.Add(secondNumbers[secondNumbers.Count - 1]);
                lastTwoValues.Add(secondNumbers[secondNumbers.Count - 2]);

                secondNumbers.RemoveAt(secondNumbers.Count - 1);
                secondNumbers.RemoveAt(secondNumbers.Count - 1);
            }

            lastTwoValues.Sort();

            List<int> allNumbers = new List<int>();
            secondNumbers.Reverse();
            
            for (int i = 0; i < firstNumbers.Count; i++)
            {
                allNumbers.Add(firstNumbers[i]);

            }
            for (int i = 0; i < secondNumbers.Count; i++)
            {
                allNumbers.Add(secondNumbers[i]);
            }

            List<int> finalList = new List<int>();

            for (int i = 0; i < allNumbers.Count; i++)
            {
                if (allNumbers[i] > lastTwoValues[0] && allNumbers[i] < lastTwoValues[lastTwoValues.Count - 1])
                {
                    finalList.Add(allNumbers[i]);
                }
            }

            finalList.Sort();

            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
