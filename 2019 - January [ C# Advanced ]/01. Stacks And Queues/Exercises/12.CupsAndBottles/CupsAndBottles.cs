using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            var cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(cups);
            var stack = new Stack<int>(bottles);

            var wasterWater = 0;
            var temp = 0;

            var currentWastedWater = stack.Peek() - queue.Peek();
            while (queue.Any() && stack.Any())
            {
                if (currentWastedWater >= 0)
                {
                    wasterWater += currentWastedWater;

                    stack.Pop();
                    queue.Dequeue();
                    if (queue.Any() && stack.Any())
                    {
                        currentWastedWater = stack.Peek() - queue.Peek();
                    }
                }
                else
                {
                    temp = Math.Abs(currentWastedWater);
                    stack.Pop();
                    currentWastedWater = stack.Peek() - temp;
                }
            }

            if (queue.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stack)}");
            }

            Console.WriteLine($"Wasted litters of water: {wasterWater}");
        }
    }
}