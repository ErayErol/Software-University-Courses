using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var resourcesQuantity = new Dictionary<string, ulong>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                ulong quantity = ulong.Parse(Console.ReadLine());

                if (!resourcesQuantity.ContainsKey(resource))
                {
                    resourcesQuantity.Add(resource, quantity);
                }
                else
                {
                    resourcesQuantity[resource] += quantity;
                }
            }

            foreach (var resourceQuantity in resourcesQuantity)
            {
                Console.WriteLine($"{resourceQuantity.Key} -> {resourceQuantity.Value}");
            }
        }
    }
}