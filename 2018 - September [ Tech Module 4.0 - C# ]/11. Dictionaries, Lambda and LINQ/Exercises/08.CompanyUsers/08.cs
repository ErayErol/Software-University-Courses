using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyNamesAndIds = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] commands = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "End")
                {
                    break;
                }

                string companyName = commands[0];
                string employeeId = commands[1];

                if (!companyNamesAndIds.ContainsKey(companyName))
                {
                    companyNamesAndIds.Add(companyName, new List<string>());
                }

                if (!companyNamesAndIds[companyName].Contains(employeeId))
                {
                    companyNamesAndIds[companyName].Add(employeeId);
                }
            }

            foreach (var kvp in companyNamesAndIds.OrderBy(x => x.Key))
            {
                string companyName = kvp.Key;
                List<string> countOfIds = kvp.Value;

                Console.WriteLine($"{companyName}");

                foreach (var id in countOfIds)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}