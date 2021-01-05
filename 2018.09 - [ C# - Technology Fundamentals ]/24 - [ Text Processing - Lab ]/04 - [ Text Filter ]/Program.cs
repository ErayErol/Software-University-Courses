using System;
using System.Collections.Generic;
using System.Linq;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine().Split(", ").ToList();
            string text = Console.ReadLine();

            foreach (var item in bannedWords)
            {
                text = text.Replace(item, new string('*', item.Count()));
            }

            Console.WriteLine(text);
        }
    }
}
