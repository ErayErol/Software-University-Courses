using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console
                .ReadLine()
                .Split()
                .ToList();

            var sb = new StringBuilder();

            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    sb.Append(words[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
