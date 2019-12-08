using MiniServer.Common;

namespace MiniServer.Headers
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(text: key, name: nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(text: value, name: nameof(value));

            this.Key = key;
            this.Value = value;
        }
        public string Key { get; }
        public string Value { get; }
        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
