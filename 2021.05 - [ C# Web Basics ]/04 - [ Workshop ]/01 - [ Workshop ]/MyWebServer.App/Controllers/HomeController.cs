namespace MyWebServer.App.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse HtmlIndex() 
            => Html("<h1>Not Found</h1>");

        public HttpResponse Index()
            => Text("<h1>Hello from HTML Home!</h1>");

        public HttpResponse ToSoftUni()
            => Redirect("https://softuni.bg");
    }
}
