using System;
using System.Collections.Generic;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>(n);

            AddingProductsToTheListAndSortThem(n, products);
        }

        static void AddingProductsToTheListAndSortThem(int n, List<string> products)
        {
            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            PrintingProducts(n, products);
        }

        static void PrintingProducts(int n, List<string> products)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i}.{products[i - 1]}");
            }
        }
    }
}
