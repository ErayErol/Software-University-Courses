namespace MyWebServer.App
{
    using MyWebServer.App.Controllers;
    using MyWebServer.Controllers;
    using System.Threading.Tasks;

    public class Startup
    {
        static async Task Main(string[] args)
        => await new HttpServer(
                routes => routes
                    .MapGet<HomeController>("/", c => c.Index())
                    .MapGet<HomeController>("/html", c => c.HtmlIndex())
                    .MapGet<HomeController>("/softuni", c => c.ToSoftUni())
                    .MapGet<AnimalController>("/Cats", c => c.Cats())
                    .MapGet<AnimalController>("/Dogs", c => c.Dogs()))
        .Start();
    }
}