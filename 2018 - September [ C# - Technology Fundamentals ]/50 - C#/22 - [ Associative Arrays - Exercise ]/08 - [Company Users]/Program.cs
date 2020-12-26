using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var dict = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                List<string> inputArgs = input
                    .Split(" -> ")
                    .ToList();

                string companyName = inputArgs[0];
                string employeeName = inputArgs[1];

                if (!dict.ContainsKey(companyName))
                {
                    dict[companyName] = new List<string>();
                }

                if (!dict[companyName].Contains(employeeName))
                {
                    dict[companyName].Add(employeeName);
                }
            }

            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                string companyName = kvp.Key;

                Console.WriteLine($"{kvp.Key}");

                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
