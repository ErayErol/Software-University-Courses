namespace TeisterMask.DataProcessor
{
    using Data;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.Utilities;

    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToArray()
                .Where(project => project.Tasks.Count > 0)
                .Select(project => new XMLProjectOutputModel()
                {
                    TasksCount = project.Tasks.Count,
                    ProjectName = project.Name,
                    HasEndDate = project.DueDate.HasValue ? "Yes" : "No",
                    Tasks = project.Tasks
                        .ToArray()
                        .Select(task => new XMLTasksOutputModel()
                        {
                            Name = task.Name,
                            Label = task.LabelType.ToString()
                        })
                        .OrderBy(exportXmlTasks => exportXmlTasks.Name)
                        .ToArray() // must be array
                })
                .OrderByDescending(exportXmlProject => exportXmlProject.TasksCount)
                .ThenBy(exportXmlProject => exportXmlProject.ProjectName)
                .ToArray();

            var result = XmlConverter.Serialize(projects, "Projects");
            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(employee => employee.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToArray()
                .Select(employee => new
                {
                    employee.Username,
                    Tasks = employee.EmployeesTasks
                        .ToArray()
                        .Select(employeeTask => employeeTask.Task)
                        .Where(task => task.OpenDate >= date)
                        .OrderByDescending(task => task.DueDate)
                        .ThenBy(task => task.Name)
                        .Select(task => new
                        {
                            TaskName = task.Name,
                            OpenDate = task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = task.LabelType.ToString(),
                            ExecutionType = task.ExecutionType.ToString(),
                        }).ToArray()
                })
                .OrderByDescending(arg => arg.Tasks.Length)
                .ThenBy(arg => arg.Username)
                .Take(10)
                .ToArray();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return result;
        }
    }
}