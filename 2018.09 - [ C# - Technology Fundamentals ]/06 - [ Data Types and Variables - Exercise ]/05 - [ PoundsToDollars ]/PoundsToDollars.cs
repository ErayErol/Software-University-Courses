namespace _05.PoundsToDollars
{
    using System;

    class PoundsToDollars
    {
        static void Main(string[] args)
        {
            decimal britishPound = decimal.Parse(Console.ReadLine());

            decimal dollars = britishPound * 1.31M;

            Console.WriteLine($"{dollars:F3}");
        }
    }
}