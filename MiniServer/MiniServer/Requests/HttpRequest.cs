using MiniServer.Common;
using MiniServer.Enums;
using MiniServer.Exceptions;
using MiniServer.Headers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniServer.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(text: requestString, name: nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length == 3 && requestLine[2] == GlobalConstans.HttpOneProtocolFragment)
            {
                return true;
            }
            return false;
        }
        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            if (queryString == "" || !(queryString is null))
            {
                if (queryParameters.Length >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        private void ParseRequestMethod(string[] requestLine)
        {
            bool parseMethod = HttpRequestMethod.TryParse(requestLine[0], true, out HttpRequestMethod method);

            if (!parseMethod)
            {
                throw new BadRequestException(GlobalConstans.SupportedHttpMethodExceptionMessage);
            }
            this.RequestMethod = method;
        }
        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }
        private void ParseRequestPath()
        {
            this.Path = this.Url.Substring(0, Url.IndexOf('?') - 1);
        }
        private void ParseHeaders(string[] requestContent)
        {
            int i = 1;
            while (requestContent[i]!=GlobalConstans.HttpNewLine)
            {
                HttpHeader httpHeader = new HttpHeader(
                    requestContent[i].Split(new char[] { ' ', ':' })[0], 
                    requestContent[i].Split(new char[] { ' ', ':' })[1]);
                this.Headers.AddHeader(httpHeader);
                i++;
            }
        }
        private void ParseQueryParameters()
        {

        }
        private void ParseFormDataParameters(string formData)
        {

        }
        private void ParseRequestParameteres(string formData)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(formData);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(separator: new[] { GlobalConstans.HttpNewLine }, StringSplitOptions.None);
            string[] requestLine = splitRequestContent[0].Trim()
                .Split(separator: new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());

            this.ParseRequestParameteres(splitRequestContent[splitRequestContent.Length - 1]);
        }

    }
}
