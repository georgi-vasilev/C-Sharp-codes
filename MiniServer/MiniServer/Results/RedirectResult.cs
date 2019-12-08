using MiniServer.Enums;
using MiniServer.Headers;
using MiniServer.Responses;

namespace MiniServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            :base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new HttpHeader(HttpHeader.Location, location));
        }
    }
}
