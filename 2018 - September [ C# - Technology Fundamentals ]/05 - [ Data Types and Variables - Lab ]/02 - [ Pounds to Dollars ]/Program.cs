using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal poundsToDollars = pounds * 1.31m;
            Console.WriteLine($"{poundsToDollars:f3}");
        }
    }
}
