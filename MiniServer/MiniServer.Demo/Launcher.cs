using MiniServer.Enums;
using MiniServer.Routing;

namespace MiniServer.Demo
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new IServerRoutingTable();

            serverRoutingTable.Add(
                HttpRequestMethod.Get,
                path: "/",
                func: request => new HomeController().Index(request));

            Server server = new Server(port: 8000, serverRoutingTable);

            server.Run();
        }
    }
}
