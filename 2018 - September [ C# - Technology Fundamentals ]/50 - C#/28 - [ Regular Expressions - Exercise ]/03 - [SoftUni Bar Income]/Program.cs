using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*?<(?<product>\w+)>[^|$%.]*?\|(?<qty>\d+)\|[^|$%.]*?(?<price>\d+(.\d+)?)\$";

            double totalPrice = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match matching = Regex.Match(input, regex);

                if (matching.Success)
                {
                    string name = matching.Groups["name"].Value;
                    string product = matching.Groups["product"].Value;
                    int qty = int.Parse(matching.Groups["qty"].Value);
                    double price = double.Parse(matching.Groups["price"].Value);

                    Console.WriteLine($"{name}: {product} - {price * qty:f2}");
                    totalPrice += price * qty;
                }
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
