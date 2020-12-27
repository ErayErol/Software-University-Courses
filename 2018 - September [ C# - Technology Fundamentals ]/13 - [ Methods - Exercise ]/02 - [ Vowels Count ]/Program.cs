using System;
using System.Collections.Generic;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            Console.WriteLine(CountingVowels(text));
        }

        static int CountingVowels(string text)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
            int vowelsCounter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (vowels.Contains(text[i]))
                {
                    vowelsCounter++;
                }
            }

            return vowelsCounter;
        }
    }
}
