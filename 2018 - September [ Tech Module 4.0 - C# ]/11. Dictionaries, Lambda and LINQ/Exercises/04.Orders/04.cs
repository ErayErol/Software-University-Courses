using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var productsQuantity = new Dictionary<string, int>();
            var productsPrice = new Dictionary<string, decimal>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "buy")
                {
                    break;
                }

                string product = commands[0];
                decimal price = decimal.Parse(commands[1]);
                int quantity = int.Parse(commands[2]);

                if (!productsPrice.ContainsKey(product))
                {
                    productsQuantity[product] = quantity;
                }
                else
                {
                    productsQuantity[product] += quantity;
                }

                productsPrice[product] = price; 
            }

            foreach (var kvp in productsQuantity)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                decimal price = productsPrice[product];

                decimal result = quantity * price;
                Console.WriteLine($"{product} -> {result:F2}");
            }
        }
    }
}