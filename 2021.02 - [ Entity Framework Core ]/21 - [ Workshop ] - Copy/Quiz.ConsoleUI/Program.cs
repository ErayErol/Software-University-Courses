using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quiz.Data;
using Quiz.Services;
using System.Collections.Generic;
using System.IO;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var jsonImporter = serviceProvider.GetService<IJsonImportService>();
            jsonImporter.Import("EF-Core-Quiz.json", "C# DB");

            //var answerService = serviceProvider.GetService<IAnswerService>();
            //answerService.Add("2", 5, true, 2);

            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            //userAnswerService.AddUserAnswer("df871d8b-1e64-49cc-92db-f35ab8a75452", 1, 2, 1);

            //var quizService = serviceProvider.GetService<IUserAnswerService>();
            //var quiz = quizService.GetUserResult("df871d8b-1e64-49cc-92db-f35ab8a75452", 1);

            //Console.WriteLine(quiz);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizSerivce>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
            services.AddTransient<IJsonImportService, JsonImportService>();
        }
    }
}
