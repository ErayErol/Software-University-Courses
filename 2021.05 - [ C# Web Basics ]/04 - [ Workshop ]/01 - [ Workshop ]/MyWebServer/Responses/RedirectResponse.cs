using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Content;
using MyWebServer.Http;

namespace MyWebServer.Responses
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location) 
            : base(HttpStatusCode.Found)
        {
            Guard.AgainstNull(nameof(location), location);

            this.Headers.Add("Location", location);
        }
    }
}
