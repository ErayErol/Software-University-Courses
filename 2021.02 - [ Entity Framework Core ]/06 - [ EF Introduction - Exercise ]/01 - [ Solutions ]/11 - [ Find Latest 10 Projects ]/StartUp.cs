namespace SoftUni
{
    using SoftUni.Data;

    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const int CountToTakeFromDatabase = 10;
        /// <summary>
        /// If judge doesn't give you points change "\n" with Environment.NewLine
        /// After that remove const or you will receive error
        /// </summary>
        private const string NewLine = "\n";
        
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();
            var result = GetLatestProjects(context);
            Console.WriteLine(result);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .OrderBy(x => x.Name)
                .Take(CountToTakeFromDatabase)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                sb.AppendLine($"{project.Name}{NewLine}{project.Description}{NewLine}{startDate}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}