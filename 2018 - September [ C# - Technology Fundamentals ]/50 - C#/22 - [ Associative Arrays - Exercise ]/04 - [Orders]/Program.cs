using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, double[]>();

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productArgs = input.Split().ToArray();

                string productName = productArgs[0];
                double productPrice = double.Parse(productArgs[1]);
                double productQty = double.Parse(productArgs[2]);

                if (!dict.ContainsKey(productName))
                {
                    dict.Add(productName, new double[2]);
                }

                dict[productName][0] = productPrice;
                dict[productName][1] += productQty;
            }

            Console.WriteLine(string.Join(Environment.NewLine, dict
                .Select(x => $"{x.Key} -> {x.Value[0] * x.Value[1]:f2}")));
        }
    }
}
