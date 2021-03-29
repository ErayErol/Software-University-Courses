namespace SoftUni
{
    using SoftUni.Data;

    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const decimal MinSalary = 50_000;

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = GetEmployeesWithSalaryOver50000(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.Salary > MinSalary)
                .OrderBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}