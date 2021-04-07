using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Server();
        }

        private static async Task ServerListen()
        {
            int port = 12345;
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ipAddress, port);
            listener.Start();

            while (true)
            {
                // Establish а connection and read request
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                var stream = client.GetStream();
                byte[] buffer = new byte[1_000_000];
                stream.Read(buffer, 0, buffer.Length);

                byte[] data = Encoding.ASCII.GetBytes("Hello!");
                client.GetStream().Write(data, 0, data.Length);
                stream.Dispose();
            }
        }

        private static async Task Server()
        {
            const string NewLine = "\r\n";
            TcpListener listener = new TcpListener(IPAddress.Loopback, 12345);
            listener.Start();

            while (true)
            {
                var socket = listener.AcceptSocket();
                byte[] buffer = new byte[51];
                var length = socket.Receive(buffer);
                string requestString =
                    Encoding.UTF8.GetString(buffer, 0, length);

                string html = $"<h1>Hello Erayski!, Date: {DateTime.Now}</h1>";

                string response =
                    $"HTTP/1.1 200 OK{NewLine}" +
                    $"Server: ErayServer8000{NewLine}" +
                    $"Content-Type: text/html; charset=utf-8{NewLine}" +
                    $"Content-Length: {html.Length}{NewLine}{NewLine}" +
                    $"{html}{NewLine}";

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                socket.Send(responseBytes);

                Console.WriteLine(requestString);
                Console.WriteLine(new string('=', 70));

                socket.Shutdown(SocketShutdown.Both);
            }
        }
    }
}