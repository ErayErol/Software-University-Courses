namespace SoftUni
{
    using SoftUni.Data;

    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string TownName = "Seattle";

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = RemoveTown(context);
            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context
                .Towns
                .FirstOrDefault(x => x.Name == TownName);

            var addresses = context
                .Addresses
                .Include(x => x.Employees)
                .Where(x => x.Town == town)
                .ToList();

            foreach (var entity in addresses)
            {
                foreach (var employee in entity.Employees.Where(x => x.AddressId == entity.AddressId))
                {
                    employee.AddressId = null;
                }

                context.Addresses.Remove(entity);
            }

            if (town != null)
            {
                context.SaveChanges();
                context.Towns.Remove(town);
                context.SaveChanges();
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{addresses.Count} addresses in Seattle were deleted");
            return sb.ToString().TrimEnd();
        }
    }
}