namespace _04.ReverseArrayОfStrings
{
    using System;
    using System.Linq;

    class ReverseArrayОfStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] items = input.Split(' ');

            var reversed = items.Reverse();

            Console.WriteLine(String.Join(" ", reversed));
        }
    }
}