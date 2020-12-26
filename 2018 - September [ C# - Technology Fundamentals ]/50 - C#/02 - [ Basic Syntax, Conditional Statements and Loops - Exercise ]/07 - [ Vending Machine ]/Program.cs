using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalSum = 0;
            while (input != "Start")
            {
                double coins = double.Parse(input);
                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    totalSum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                input = Console.ReadLine();
            }

            string product = Console.ReadLine();
            double price = 0;
            while (product != "End")
            {
                bool flag = true;
                if (product == "Nuts")
                {
                    price = 2;
                }
                else if (product == "Water")
                {
                    price = 0.7;
                }
                else if (product == "Crisps")
                {
                    price = 1.5;
                }
                else if (product == "Soda")
                {
                    price = 0.8;
                }
                else if (product == "Coke")
                {
                    price = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    flag = false;
                }

                if (totalSum >= price && flag)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    totalSum -= price;
                }
                else if (flag)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {totalSum:f2}");
        }
    }
}
