using System;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                char[] reverse = input.ToCharArray();
                Array.Reverse(reverse);
                Console.WriteLine($"{input} = {string.Join("", reverse)}");
            }
        }
    }
}