using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> allNumbers = new List<int>();

            for (int i = 0; i < 1; i++)
            {
                allNumbers.Add(firstNumbers[i]);
                firstNumbers.RemoveAt(i);

                allNumbers.Add(secondNumbers[secondNumbers.Count - 1 - i]);
                secondNumbers.RemoveAt(secondNumbers.Count - 1 - i);
                i--;

                if (firstNumbers.Count == 0 || secondNumbers.Count == 0)
                {
                    break;
                }
            }

            List<int> rangeNumbers = new List<int>();

            if (firstNumbers.Count == 2)
            {
                rangeNumbers = new List<int>(firstNumbers);
            }
            else if (secondNumbers.Count == 2)
            {
                rangeNumbers = new List<int>(secondNumbers);
            }
            else
            {
                Console.WriteLine(string.Join(" ", allNumbers.OrderBy(n => n)));
                return;
            }

            List<int> result = new List<int>();

            for (int i = 0; i < allNumbers.Count; i++)
            {
                if (allNumbers[i] > rangeNumbers.Min() && allNumbers[i] < rangeNumbers.Max())
                {
                    result.Add(allNumbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result.OrderBy(n => n)));
        }
    }
}