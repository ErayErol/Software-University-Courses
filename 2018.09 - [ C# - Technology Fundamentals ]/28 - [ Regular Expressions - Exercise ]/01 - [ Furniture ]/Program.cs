using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<furnitureName>\w+)<<(?<furniturePrice>\d+(.\d+)?)!(?<furnitureQty>\d+)";

            string input;
            double totalPrice = 0;

            List<string> furnitures = new List<string>();

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match matching = Regex.Match(input, regex);

                if (matching.Success)
                {
                    string furnitureName = matching.Groups["furnitureName"].Value;
                    double furniturePrice = double.Parse(matching.Groups["furniturePrice"].Value);
                    int furnitureQty = int.Parse(matching.Groups["furnitureQty"].Value);

                    totalPrice += furniturePrice * furnitureQty;
                    furnitures.Add(furnitureName);
                }
            }

            Console.WriteLine($"Bought furniture:");

            if (furnitures.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitures));
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
