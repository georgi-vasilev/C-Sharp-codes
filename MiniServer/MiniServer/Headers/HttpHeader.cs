using System;
using System.Collections.Generic;
using System.Text;
using MiniServer.Common;

namespace MiniServer.Headers
{
    class HttpHeader : CoreValidator
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
