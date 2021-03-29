namespace SoftUni
{
    using SoftUni.Data;

    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const int CountToTakeFromDatabase = 10;

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = GetAddressesByTown(context);
            Console.WriteLine(result);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                    .Addresses
                    .Select(x => new
                    {
                        EmployeeCount = x.Employees.Count,
                        x.AddressText,
                        TownName = x.Town.Name,
                    })
                    .OrderByDescending(x => x.EmployeeCount)
                    .ThenBy(x => x.TownName)
                    .ThenBy(x => x.AddressText)
                    .Take(CountToTakeFromDatabase)
                    .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}