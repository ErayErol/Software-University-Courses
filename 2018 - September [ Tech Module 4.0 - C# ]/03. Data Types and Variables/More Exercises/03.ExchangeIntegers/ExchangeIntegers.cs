namespace _03.ExchangeIntegers
{
    using System;

    class ExchangeIntegers
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            Console.WriteLine("Before:");
            Console.WriteLine($"a = {first}");
            Console.WriteLine($"b = {second}");

            string temp = first;
            first = second;
            second = temp;

            Console.WriteLine("After:");
            Console.WriteLine($"a = {first}");
            Console.WriteLine($"b = {second}");
        }
    }
}