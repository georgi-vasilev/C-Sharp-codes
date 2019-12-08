using MiniServer.Enums;
using MiniServer.Headers;
using MiniServer.Responses;
using System.Text;

namespace MiniServer.Results
{
    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader(
                "Content-Type", "text/html; chartset=utf-8"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
