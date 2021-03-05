namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = GetEmployeesInPeriod(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Include(x => x.Manager)
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(employee => employee.EmployeesProjects
                    .Any(project => project.Project.StartDate.Year >= 2001 && project.Project.StartDate.Year <= 2003))
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                foreach (var project in employee.EmployeesProjects)
                {
                    var startDate = project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = project.Project.EndDate == null 
                            ? "not finished" 
                            : project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.Project.Name} - {startDate} - {endDate}");
                }
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string GetEmployeesInPeriod2(SoftUniContext context)
        {
            var employees = context
                .EmployeesProjects
                .Include(x => x.Project)
                .Include(x => x.Employee)
                .Where(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003)
                .AsEnumerable()
                .GroupBy(x => x.Employee)
                .ToDictionary(y => y.Key, z => z.Select(z => z.Project))
                .Take(10);

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                var manager = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.Key.ManagerId);
                if (manager != null)
                {
                    sb.AppendLine(
                        $"{employee.Key.FirstName} {employee.Key.LastName} - Manager: {manager.FirstName} {manager.LastName}");
                }

                foreach (var project in employee.Value)
                {
                    sb.AppendLine($"--{project.Name} -" +
                                  $" {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                                  $"{(project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}