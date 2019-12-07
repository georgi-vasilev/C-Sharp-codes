using System;
using System.Collections.Generic;
using System.Text;

namespace MiniServer.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
        }

        public bool ConstainsHeader(string key)
        {
            throw new NotImplementedException();
        }

        public HttpHeader GetHeader(string key)
        {
            throw new NotImplementedException();
        }
    }
}
