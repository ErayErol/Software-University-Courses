using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalPrice = 0.0m;
            List<string> boughtFurniture = new List<string>();
            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "Purchase")
                {
                    if (boughtFurniture.Count > 0)
                    {
                        Console.WriteLine("Bought furniture:");
                        Console.WriteLine(string.Join(Environment.NewLine, boughtFurniture));
                        Console.WriteLine($"Total money spend: {totalPrice:F2}");
                    }

                    break;
                }

                string pattern = @">>(?<name>\w+)<<(?<price>\d+(\.\d+)?)\!(?<quantity>\d)+";
                MatchCollection regex = Regex.Matches(commands, pattern);
                foreach (Match match in regex)
                {
                    boughtFurniture.Add(match.Groups["name"].Value);
                    var currentSum = (decimal.Parse(match.Groups["price"].Value)) * (decimal.Parse(match.Groups["quantity"].Value));
                    totalPrice += currentSum;
                }
            }
        }
    }
}