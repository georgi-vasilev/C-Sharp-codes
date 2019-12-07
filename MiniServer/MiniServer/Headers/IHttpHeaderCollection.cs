using System;
using System.Collections.Generic;
using System.Text;

namespace MiniServer.Headers
{
    public interface IHttpHeaderCollection
    {
        void AddHeader(HttpHeader header);

        bool ConstainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}
