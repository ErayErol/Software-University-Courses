using SoftUni.Models;

namespace SoftUni
{
    using SoftUni.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string AddressText = "Vitoshka 15";
        private const string EmployeeLastName = "Nakov";

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = AddNewAddressToEmployee(context);
            Console.WriteLine(result);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address()
            {
                AddressText = AddressText,
                TownId = 4
            };

            var employee = context
                .Employees
                .FirstOrDefault(e => e.LastName == EmployeeLastName);

            employee.Address = address;
            context.SaveChanges();

            var employees = context
                .Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => new {x.Address.AddressText})
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.AddressText}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}