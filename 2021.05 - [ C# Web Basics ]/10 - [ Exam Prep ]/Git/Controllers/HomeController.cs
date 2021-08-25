namespace Git.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            // if User is 'logged in'
            // => this.User.IsAuthenticated return true
            // in our situation Redirect("Views/Repositories/All.cshtml") 

            // if User is NOT 'logged in'
            // => this.User.IsAuthenticated return false
            // in our situation Redirect("Views/Home/Index.cshtml") 

            return this.User.IsAuthenticated 
                ? Redirect("/Repositories/All") 
                : View();
        }
    }
}
