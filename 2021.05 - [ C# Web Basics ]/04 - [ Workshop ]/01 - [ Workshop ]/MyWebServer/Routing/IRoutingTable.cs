namespace MyWebServer.Routing
{
    using MyWebServer.Http;
    using System;

    public interface IRoutingTable
    {
        IRoutingTable Map(Method method, string path, HttpResponse response);

        IRoutingTable Map(Method method, string path, Func<HttpRequest, HttpResponse> responseFunc);

        IRoutingTable MapGet(string path, HttpResponse response);

        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunc);

        IRoutingTable MapPost(string path, HttpResponse response);

        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunc);
    }
}
