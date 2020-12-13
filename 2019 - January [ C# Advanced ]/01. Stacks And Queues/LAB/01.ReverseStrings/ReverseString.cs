using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversed = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reversed.Push(input[i]);
            }

            Console.WriteLine(string.Join("", reversed));
        }
    }
}