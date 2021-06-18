namespace MyWebServer.App.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class AnimalController : Controller
    {
        public AnimalController(HttpRequest request) 
            : base(request)
        {
        }
        
        public HttpResponse Cats()
        {
            const string nameKey = "Name";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey)
                ? query[nameKey]
                : "the cats";

            var result = $"<h1>Hello from {catName}</h1>";

            return Html(result);
        }

        public HttpResponse Dogs()
        {
            const string nameKey = "Name";

            var query = this.Request.Query;

            var dogName = query.ContainsKey(nameKey)
                ? query[nameKey]
                : "the dogs";

            var result = $"<h1>Hello from {dogName}</h1>";

            return Html(result);
        }
    }
}