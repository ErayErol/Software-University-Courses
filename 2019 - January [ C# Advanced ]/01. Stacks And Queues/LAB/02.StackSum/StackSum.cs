using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                stack.Push(nums[i]);
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0].ToLower())
                {
                    case "end":
                        Console.WriteLine($"Sum: {stack.OrderBy(num => num).ToArray().Sum()}");
                        return;

                    case "add":
                        int first = int.Parse(commands[1]);
                        int second = int.Parse(commands[2]);
                        stack.Push(first);
                        stack.Push(second);
                        break;

                    case "remove":
                        int numsForRemove = int.Parse(commands[1]);
                        if (stack.Count >= numsForRemove)
                        {
                            for (int i = 0; i < numsForRemove; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }
        }
    }
}