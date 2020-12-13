using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string products = Console.ReadLine().ToLower();
            var quantity = double.Parse(Console.ReadLine());

            GetPriceOfOrders(products, quantity);
        }

        private static void GetPriceOfOrders(string products, double quantity)
        {
            double price = 0.0;

            switch (products)
            {
                case "coffee": price = 1.5; break;
                case "water": price = 1.0; break;
                case "coke": price = 1.4; break;
                case "snacks": price = 2.0; break;
            }

            price *= quantity;
            Console.WriteLine("{0:F2}", price);
        }
    }
}