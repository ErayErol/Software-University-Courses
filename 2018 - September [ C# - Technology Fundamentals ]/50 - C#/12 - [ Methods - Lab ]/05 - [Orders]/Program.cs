using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double qty = double.Parse(Console.ReadLine());

            Console.WriteLine($"{TotalPriceOfThePurchase(product, qty):f2}");
        }

        static double TotalPriceOfThePurchase(string product, double qty)
        {

            double totalPrice = 0;

            if (product == "coffee")
            {
                totalPrice = qty * 1.50;
            }
            else if (product == "water")
            {
                totalPrice = qty * 1.00;
            }
            else if (product == "coke")
            {
                totalPrice = qty * 1.40;
            }
            else if (product == "snacks")
            {
                totalPrice = qty * 2.00;
            }

            return totalPrice;
        }
    }
}
