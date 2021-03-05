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
            var result = GetEmployee147(context);
            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context
                .Employees
                .Where(employee => employee.EmployeeId == 147)
                .Select(employee => new
                {
                    employee.FirstName,
                    employee.LastName,
                    employee.JobTitle,
                    Projects = employee.EmployeesProjects
                        .Select(project => new
                        {
                            project.Project.Name
                        })
                        .OrderBy(x => x.Name)
                        .ToList(),
                })
                .FirstOrDefault();

            StringBuilder sb = new StringBuilder();
            if (employee147 != null)
            {
                sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
                foreach (var project in employee147.Projects)
                {
                    sb.AppendLine(project.Name);
                }
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}