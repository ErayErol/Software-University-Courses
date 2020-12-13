using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(bullets);
            var queue = new Queue<int>(locks);
            var bulletCount = 0;

            while (stack.Any() && queue.Any())
            {
                if (stack.Pop() > queue.Peek())
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    queue.Dequeue();
                }

                bulletCount++;
                if (bulletCount % size == 0 && stack.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (queue.Any() == false)
            {
                var sum = value - (bulletCount * price);
                Console.WriteLine($"{stack.Count} bullets left. Earned ${sum}");
                return;
            }

            Console.WriteLine($"Couldn't get through. Locks left: {queue.Count}");
        }
    }
}