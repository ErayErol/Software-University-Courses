using System;
using System.Collections.Generic;

namespace _05.Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            var queues = new Queue<string>();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "End")
                {
                    Console.WriteLine($"{queues.Count} people remaining.");

                    break;
                }
                else if (commands == "Paid")
                {
                    while (queues.Count > 0)
                    {
                        Console.WriteLine(queues.Dequeue());
                    }

                    continue;
                }

                queues.Enqueue(commands);
            }
        }
    }
}