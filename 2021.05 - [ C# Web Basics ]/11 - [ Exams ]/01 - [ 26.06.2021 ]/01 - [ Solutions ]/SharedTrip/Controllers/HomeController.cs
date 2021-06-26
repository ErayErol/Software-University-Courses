namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            return this.User.IsAuthenticated
                ? Redirect("/Trips/All")
                : View();
        }
    }
}