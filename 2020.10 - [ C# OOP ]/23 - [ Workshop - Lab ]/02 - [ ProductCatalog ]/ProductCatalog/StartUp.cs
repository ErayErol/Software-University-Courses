using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCatalog.Infrastucture.Data;
using ProductCatalog.Utilities;
using System;

namespace ProductCatalog
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependancyResolver.GetServiceProvider();

            var app = serviceProvider.GetService<Application>();

            using (serviceProvider.CreateScope())//
            {
                app.Run(args);
            }
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[]  args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostcontext, services) =>
                {
                    services.AddDbContext<ApplicationDBContext>(o => o.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dotnet-productcatalog;Trusted_Connection=True;MultipleActiveResultSets=true"));
                });
        }
    }
}
