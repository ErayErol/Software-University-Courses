namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;

    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const int CountToTakeFromDatabase = 10;
        private const string AddressText = "Vitoshka 15";
        private const string EmployeeLastName = "Nakov";
        private const int TownId = 4;

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
                TownId = TownId
            };

            var employee = context
                .Employees
                .FirstOrDefault(e => e.LastName == EmployeeLastName);

            if (employee != null)
            {
                employee.Address = address;
                context.SaveChanges();
            }

            var employees = context
                .Employees
                .OrderByDescending(x => x.AddressId)
                .Take(CountToTakeFromDatabase)
                .Select(x => new
                {
                    x.Address.AddressText
                })
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