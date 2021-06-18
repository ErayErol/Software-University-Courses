using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyDemoServer
{
    class Program
    {
        private const string IpAdress = "127.0.0.1";

        static async Task Main(string[] args)
        {
            IPAddress address = IPAddress.Parse(IpAdress);
            int port = 1234;

            TcpListener listener = new TcpListener(address, port);

            listener.Start();
            Console.WriteLine("Waiting for connection...");

            while (true)
            {
                var client = await listener.AcceptSocketAsync();
                Console.WriteLine("Connected!");

                var stream = new NetworkStream(client);

                byte[] myReadBuffer = new byte[1024];
                StringBuilder myCompleteMessage = new StringBuilder();

                // Incoming message may be larger than the buffer size.
                do
                {
                    var numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    stream.ReadTimeout = 250;

                    myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                }
                while (stream.DataAvailable);

                // Print out the received message to the console.
                Console.WriteLine("You received the following message : " + myCompleteMessage);


                var content = "<html>\r\n" +
                              "<head>\r\n" +
                              "<meta charset=utf-8>\r\n" +
                              "</head>\r\n" +
                              "<body>\r\n" +
                              "<h1>Здрасти, аз съм Ерайски!</h1>\r\n" +
                              "</body>\r\n" +
                              "</html>";
                var contentLength = Encoding.UTF8.GetByteCount(content);

                var response = $@"
HTTP/1.1 200 OK
Date: {DateTime.UtcNow:R}
Server: Demo Web Server
Content-Length: {contentLength}
Content-Type text/html; charset=UTF-8

{content}";

                var myWriteBuffer = Encoding.UTF8.GetBytes(response);

                await stream.WriteAsync(myWriteBuffer, 0, myWriteBuffer.Length);

                client.Close();
            }
        }
    }
}
