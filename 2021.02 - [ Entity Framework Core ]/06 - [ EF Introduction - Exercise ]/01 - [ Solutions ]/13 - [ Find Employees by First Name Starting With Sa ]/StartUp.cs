namespace SoftUni
{
    using SoftUni.Data;

    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string FirstNameStartingWith = "sa%";

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = GetEmployeesByFirstNameStartingWithSa(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => EF.Functions.Like(x.FirstName, FirstNameStartingWith))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}