using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var wasterWater = 0;
            var left = 0;

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
                    stack.Pop();
                    left = Math.Abs(currentWastedWater);
                    currentWastedWater = stack.Peek() - left;
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