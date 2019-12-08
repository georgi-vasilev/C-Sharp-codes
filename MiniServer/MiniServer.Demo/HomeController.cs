using MiniServer.Enums;
using MiniServer.Responses;
using MiniServer.Results;

namespace MiniServer.Demo
{
    public class HomeController
    {
        public IHttpResponse Index(IHttpResponse request)
        {
            string content = "<h1> Hello, World!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
