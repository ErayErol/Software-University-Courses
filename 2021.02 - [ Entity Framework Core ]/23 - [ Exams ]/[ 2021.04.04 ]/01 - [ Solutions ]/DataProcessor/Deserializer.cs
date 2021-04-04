namespace TeisterMask.DataProcessor
{
    using Data;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Utilities;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var dtoProjects = XmlConverter.Deserializer<XMLProjectInputModel>(xmlString, "Projects");
            var output = new StringBuilder();

            foreach (var dtoProject in dtoProjects)
            {
                var isValidOpenDateProject = DateTime.TryParseExact(dtoProject.OpenDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var openDateProject);

                if (IsValid(dtoProject) == false || isValidOpenDateProject == false)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidDueDateProject = DateTime.TryParseExact(dtoProject.DueDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDateProject);

                var project = new Project()
                {
                    Name = dtoProject.Name,
                    OpenDate = openDateProject,
                    DueDate = isValidDueDateProject ? dueDateProject : (DateTime?)null,
                };

                foreach (var dtoTask in dtoProject.Tasks)
                {
                    var isValidOpenDateTask = DateTime.TryParseExact(dtoTask.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var openDateTask);

                    var isValidDueDateTask = DateTime.TryParseExact(dtoTask.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDateTask);


                    if (IsValid(dtoTask) == false || isValidDueDateTask == false || isValidOpenDateTask == false)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (openDateTask < openDateProject || dueDateTask > dueDateProject && dueDateProject.Year > 1)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task()
                    {
                        Name = dtoTask.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = (ExecutionType)dtoTask.ExecutionType,
                        LabelType = (LabelType)dtoTask.LabelType,
                    };

                    project.Tasks.Add(task);
                }

                context.Projects.Add(project);
                context.SaveChanges();

                output.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            var result = output.ToString().TrimEnd();
            return result;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var dtoEmployees = JsonConvert.DeserializeObject<JSONEmployeeInputModel[]>(jsonString);
            var output = new StringBuilder();

            foreach (var dtoEmployee in dtoEmployees)
            {
                if (IsValid(dtoEmployee) == false)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = dtoEmployee.Username,
                    Email = dtoEmployee.Email,
                    Phone = dtoEmployee.Phone,
                };

                foreach (var taskId in dtoEmployee.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == taskId);

                    if (task == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { Task = task });
                }

                context.Employees.Add(employee);
                context.SaveChanges();

                output.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            var result = output.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}