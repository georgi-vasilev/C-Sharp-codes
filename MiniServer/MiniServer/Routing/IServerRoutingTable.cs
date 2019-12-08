using MiniServer.Enums;
using MiniServer.Requests;
using System;

namespace MiniServer.Routing
{
    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpRequest> func);

        bool Contains(HttpRequestMethod requestMethod, string path);

        Func<IHttpRequest, IHttpRequest> Get(HttpRequest requestMethod, string path);
    }
}
