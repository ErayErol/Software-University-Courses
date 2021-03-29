namespace SoftUni
{
    using SoftUni.Data;

    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const decimal IncreaseSalaryPercent = 1.12m;

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = IncreaseSalaries(context);
            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employees = context
                .Employees
                .Where(x => departments.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            employees.ForEach(x => x.Salary *= IncreaseSalaryPercent);
            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}