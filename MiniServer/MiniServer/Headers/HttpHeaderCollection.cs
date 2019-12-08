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
            headers.Add(header.Key, header);
        }

        public bool ConstainsHeader(string key)
        {
            return headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (ConstainsHeader(key))
            {
                return headers[key];
            }
            return null;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in headers)
            {
                result.Append(item.Value.ToString() + "\r\n");
            }
            return result.ToString();

        }
    }
}
