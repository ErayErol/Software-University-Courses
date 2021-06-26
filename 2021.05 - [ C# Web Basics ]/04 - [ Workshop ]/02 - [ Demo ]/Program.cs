using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyDemoServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Action<string> meAction = Console.WriteLine;

            meAction("asd");
        }
    }


}
