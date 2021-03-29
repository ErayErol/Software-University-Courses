namespace SoftUni
{
    using SoftUni.Data;

    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string DepartmentName = "Research and Development";

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.Department.Name == DepartmentName)
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department,
                    x.Salary
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}