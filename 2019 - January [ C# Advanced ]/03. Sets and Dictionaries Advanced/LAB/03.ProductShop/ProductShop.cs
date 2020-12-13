using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> productShop = new SortedDictionary<string, List<string>>();

            while (true)
            {
                var commands = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Revision")
                {
                    foreach (var kv in productShop)
                    {
                        Console.WriteLine($"{kv.Key}->\r\n{string.Join("\r\n", kv.Value)}");
                    }
                    break;
                }

                string shop = commands[0];
                string product = commands[1];
                double price = double.Parse(commands[2]);

                if (productShop.ContainsKey(shop) == false)
                {
                    productShop.Add(shop, new List<string>());
                }
                productShop[shop].Add($"Product: {product}, Price: {price}");
            }
        }
    }
}