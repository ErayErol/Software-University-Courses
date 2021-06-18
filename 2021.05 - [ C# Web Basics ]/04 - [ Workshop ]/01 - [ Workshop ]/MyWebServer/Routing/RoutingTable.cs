using System;
using System.Collections.Generic;
using MyWebServer.Content;
using MyWebServer.Http;
using MyWebServer.Responses;

namespace MyWebServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
        {
            this.routes = new()
            {
                [Method.Get] = new(),
                [Method.Post] = new(),
                [Method.Put] = new(),
                [Method.Delete] = new(),
            };
        }

        public IRoutingTable Map(Method method, string path, HttpResponse response)
        {
            Guard.AgainstNull(response, nameof(response));

            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(Method method, string path, Func<HttpRequest, HttpResponse> responseFunc)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunc, nameof(responseFunc));

            this.routes[method][path.ToLower()] = responseFunc;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response) 
            => this.MapGet(path, request => response);

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunc) 
            => this.Map(Method.Get, path, responseFunc);

        public IRoutingTable MapPost(string path, HttpResponse response) 
            => this.MapPost(path, request => response);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunc) 
            => this.Map(Method.Post, path, responseFunc);

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (this.routes.ContainsKey(request.Method) == false || this.routes[requestMethod].ContainsKey(requestPath) == false)
            {
                return new NotFoundResponse();
            }

            var responseFunc = this.routes[requestMethod][requestPath];

            return responseFunc(request);
        }
    }
}