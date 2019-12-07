using MiniServer.Enums;
using MiniServer.Headers;

namespace MiniServer.Responses
{
    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        IHttpHeaderCollection Headers { get; }
        byte[] Content { get; set; }
        void AddHeader(HttpHeader header);
        byte[] GetBytes();
    }
}
