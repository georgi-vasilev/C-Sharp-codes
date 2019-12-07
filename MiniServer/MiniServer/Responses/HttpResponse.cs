using MiniServer.Common;
using MiniServer.Enums;
using MiniServer.Headers;
using System;
using System.Text;

namespace MiniServer.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }
        public HttpResponse(HttpResponseStatusCode statusCode)
            :this()
        {
            CoreValidator.ThrowIfNull(statusCode, name: nameof(statusCode));
            this.StatusCode = statusCode;
        }
        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, name: nameof(header));
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstans.HttpOneProtocolFragment} {(int)this.StatusCode} {this.StatusCode.ToString()}")
                .Append(GlobalConstans.HttpNewLine)
                .Append(this.Headers)
                .Append(GlobalConstans.HttpNewLine);

            result.Append(GlobalConstans.HttpNewLine);

            return result.ToString();
        }
    }
}
