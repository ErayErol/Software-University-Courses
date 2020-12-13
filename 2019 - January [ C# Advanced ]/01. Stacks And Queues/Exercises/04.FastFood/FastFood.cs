using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            Queue<int> queues = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(queues.Max());

            if (quantityOfFood >= queues.Sum())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                while (quantityOfFood > queues.Peek())
                {
                    quantityOfFood = quantityOfFood - queues.Dequeue();
                }

                Console.WriteLine($"Orders left: {string.Join(" ", queues)}");
            }
        }
    }
}