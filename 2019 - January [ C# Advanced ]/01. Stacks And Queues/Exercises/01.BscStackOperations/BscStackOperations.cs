using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BscStackOperations
{
    class BscStackOperations
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var input2 = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var stack = new Stack<long>(input2);

            for (long i = 0; i < input[1] && stack.Count > 0; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }
            if (stack.Contains(input[2]))
            {
                Console.WriteLine("true");
                Environment.Exit(0);
            }

            Console.WriteLine(stack.Min());
        }
    }
}