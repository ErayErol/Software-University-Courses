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
            var result = GetDepartmentsWithMoreThan5Employees(context);
            Console.WriteLine(result);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(department => department.Employees.Count > 5)
                .Include(x => x.Manager)
                .Include(x => x.Employees)
                .OrderBy(department => department.Employees.Count)
                .ThenBy(x => x.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                var employees = department.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

                foreach (var employee in employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}