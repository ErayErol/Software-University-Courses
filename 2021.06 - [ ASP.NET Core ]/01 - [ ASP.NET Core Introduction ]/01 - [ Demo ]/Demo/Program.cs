using System;
using System.Net;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = new WebClient().DownloadString("https://medina-med.com/katalog-gumi/?application_id=car&season=summer%2Callseason&width=275&height=40&rim=20");
            ;
        }
    }
}
