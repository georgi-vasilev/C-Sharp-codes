using MiniServer.Common;
using MiniServer.Enums;
using MiniServer.Exceptions;
using MiniServer.Requests;
using MiniServer.Responses;
using MiniServer.Results;
using MiniServer.Routing;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, name: nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, name: nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public void ProcessRequest()
        {
            try
            {
                var httpRequest = this.ReadRequest();

                if (httpRequest != null)
                {
                    Console.WriteLine(value: $"Processing: {httpRequest.RequestMethod} {httpRequest.Path}...");

                    var httpResponse = this.HandleRequest(httpRequest);

                    this.PrepareResponse(httpRequest);
                }
            }
            catch (BadRequestException e)
            {
                this.PrepareResponse(new TextResult(e.ToString(), HttpResponseStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                this.PrepareResponse(new TextResult(e.ToString(), HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(how: SocketShutdown.Both);
        }
        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(array: new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, index: 0, count: numberOfBytesRead);
                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }
            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }
        private IHttpRequest HandleRequest(IHttpRequest httpRequest)
        {
            if (!this.serverRoutingTable.Contains(httpRequest.RequestMethod, httpRequest.Path))
            {
                return new TextResult(content: $"Route with method {httpRequest.RequestMethod} and path \"{httpRequest.Path}\" not found.", HttpResponseStatusCode.NotFound);
            }
            
            return this.serverRoutingTable.Get(httpRequest.RequestMethod, httpRequest.Path).Invoke(httpRequest);
        }
        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();

            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }
    }
}
