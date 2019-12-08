using MiniServer.Enums;
using MiniServer.Requests;
using System;
using System.Collections.Generic;

namespace MiniServer.Routing
{
    public class ServerRoutingTable : IServerRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpRequest>>> routes;


        public ServerRoutingTable()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpRequest>>>
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpRequest>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpRequest>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpRequest>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpRequest>>()
            };
        }


        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpRequest> func)
        {

        }

        public bool Contains(HttpRequestMethod requestMethod, string path)
        {

        }

        public Func<IHttpRequest, IHttpRequest> Get(HttpRequestMethod requestMethod, string path)
        {

        }
    }
}
