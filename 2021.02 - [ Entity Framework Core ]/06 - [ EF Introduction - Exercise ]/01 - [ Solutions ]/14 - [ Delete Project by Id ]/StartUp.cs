namespace SoftUni
{
    using SoftUni.Data;

    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const int ProjectId = 2;

        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = DeleteProjectById(context);
            Console.WriteLine(result);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project2 = context
                .Projects
                .FirstOrDefault(x => x.ProjectId == ProjectId);

            foreach (var entity in context.EmployeesProjects.Where(x => x.ProjectId == ProjectId))
            {
                context.EmployeesProjects.Remove(entity);
            }

            context.SaveChanges();

            if (project2 != null)
            {
                context.Projects.Remove(project2);
                context.SaveChanges();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var project in context.Projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}