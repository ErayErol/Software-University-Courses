namespace _04.FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));
            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 == 1;

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int startNum = input[0];
            int endNum = input[1];

            List<int> numbers = new List<int>();
            for (int num = startNum; num <= endNum; num++)
            {
                numbers.Add(num);
            }

            var result = new Dictionary<string, List<int>>()
            {
                ["even"] = numbers.FindAll(isEven),
                ["odd"] = numbers.FindAll(isOdd)
            };

            string numberType = Console.ReadLine();
            print(result[numberType]);
        }
    }
}