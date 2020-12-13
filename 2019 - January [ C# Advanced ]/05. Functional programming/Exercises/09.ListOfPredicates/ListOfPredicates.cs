namespace _09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            var endOfTheRange = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var nums = new List<int>();
            for (int i = 1; i <= endOfTheRange; i++)
            {
                nums.Add(i);
            }

            for (int i = 0; i < dividers.Count; i++)
            {
                Predicate<int> isDivisible = n => n % dividers[i] != 0;
                nums.RemoveAll(isDivisible);
            }

            print(nums);
        }
    }
}