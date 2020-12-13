namespace _05.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Func<int, int> add = x => ++x;
            Func<int, int> subtract = x => --x;
            Func<int, int> multiply = x => x * 2;
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        nums = nums.Select(add).ToList();
                        break;
                    case "subtract":
                        nums = nums.Select(subtract).ToList();
                        break;
                    case "multiply":
                        nums = nums.Select(multiply).ToList();
                        break;
                    case "print":
                        print(nums);
                        break;
                    case "end":
                        return;
                    default:
                        // throw new exception
                        break;
                }

            }
        }
    }
}