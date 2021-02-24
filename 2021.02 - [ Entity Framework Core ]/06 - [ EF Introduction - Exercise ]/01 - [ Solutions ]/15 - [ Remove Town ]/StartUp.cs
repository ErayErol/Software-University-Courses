namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
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
                .FirstOrDefault(x => x.Name == "Seattle");

            var addresses = context
                .Addresses
                .Include(x => x.Employees)
                .Where(x => x.Town == town)
                .ToList();

            var counter = 0;
            foreach (var entity in addresses)
            {
                foreach (var employee in entity.Employees.Where(x => x.AddressId == entity.AddressId))
                {
                    employee.AddressId = null;
                }

                context.Addresses.Remove(entity);
                counter++;
            }

            context.SaveChanges();
            context.Towns.Remove(town);
            context.SaveChanges();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{counter} addresses in Seattle were deleted");
            return sb.ToString().TrimEnd();
        }
    }
}