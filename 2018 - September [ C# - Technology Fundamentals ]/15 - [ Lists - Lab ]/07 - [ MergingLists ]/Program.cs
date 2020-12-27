using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.
                ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.
                ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            MergingTwoLists(firstList, secondList);
        }

        static void MergingTwoLists(List<int> firstList, List<int> secondList)
        {
            List<int> finalList = new List<int>();

            int smallest = Math.Min(firstList.Count, secondList.Count);
            int biggest = Math.Max(firstList.Count, secondList.Count);

            for (int i = 0; i < smallest; i++)
            {
                finalList.Add(firstList[i]);
                finalList.Add(secondList[i]);
            }

            if (isCountOfTheseListsEqual(firstList, secondList))
            {
                AddingRemainingElements(firstList, secondList, smallest, biggest, finalList);
            }

            Console.WriteLine(string.Join(" ", finalList));
        }

        static bool isCountOfTheseListsEqual(List<int> firstList, List<int> secondList)
        {
            if (firstList.Count != secondList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void AddingRemainingElements(List<int> firstList, List<int> secondList, int smallest, int biggest, List<int> finalList)
        {
            if (firstList.Count > secondList.Count)
            {
                for (int i = smallest; i < biggest; i++)
                {
                    finalList.Add(firstList[i]);
                }
            }
            else
            {
                for (int i = smallest; i < biggest; i++)
                {
                    finalList.Add(secondList[i]);
                }
            }
        }
    }
}
