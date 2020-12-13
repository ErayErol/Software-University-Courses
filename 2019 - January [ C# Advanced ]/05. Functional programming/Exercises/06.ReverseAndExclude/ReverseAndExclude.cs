namespace _06.ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            nums.Reverse();

            var divisible = int.Parse(Console.ReadLine());

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            Predicate<int> isDivisible = n => n % divisible == 0;

            nums.RemoveAll(isDivisible);
            print(nums);
        }
    }
}