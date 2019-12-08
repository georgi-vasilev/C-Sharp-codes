namespace MiniServer.Headers
{
    public interface IHttpHeaderCollection
    {
        void AddHeader(HttpHeader header);

        bool ConstainsHeader(string key);

        HttpHeader GetHeader(string key);
    }
}
