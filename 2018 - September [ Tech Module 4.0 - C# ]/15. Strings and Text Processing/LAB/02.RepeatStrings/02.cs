using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                for (int e = 0; e < words[i].Length; e++)
                {
                    result.Append(words[i]);
                }
            }

            Console.WriteLine(result);
        }
    }
}