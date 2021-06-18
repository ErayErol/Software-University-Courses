using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Http;
using MyWebServer.Routing;

namespace MyWebServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.listener = new TcpListener(this.ipAddress, port);
            this.routingTable = new RoutingTable();
            routingTableConfiguration(this.routingTable);
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(5000, routingTable)
        {
        }

        public async Task Start()
        {
            this.listener.Start();
            Console.Write("Waiting for a connection... ");

            while (true)
            {
                TcpClient connection = await this.listener.AcceptTcpClientAsync();
                Console.WriteLine("Connected!");

                NetworkStream stream = connection.GetStream();

                var requestText = await this.ReadRequestAsync(stream);

                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                var response = this.routingTable.ExecuteRequest(request);

                await this.WriteResponseAsync(stream, response);

                connection.Close();
            }
        }

        private async Task<string> ReadRequestAsync(NetworkStream stream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = await stream.ReadAsync(buffer, 0, bufferLength);
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (stream.DataAvailable);

            return requestBuilder.ToString();
        }

        private async Task WriteResponseAsync(NetworkStream stream, HttpResponse response)
        {
            var bytes = Encoding.UTF8.GetBytes(response.ToString());
            await stream.WriteAsync(bytes);
        }
    }
}
