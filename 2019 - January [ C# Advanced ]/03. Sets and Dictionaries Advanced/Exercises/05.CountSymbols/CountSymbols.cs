using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                var currentSymbol = text[i];
                if (dictionary.ContainsKey(currentSymbol) == false)
                {
                    dictionary.Add(currentSymbol, 0);
                }
                dictionary[currentSymbol]++;
            }

            foreach (var kv in dictionary)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value} time/s");
            }
        }
    }
}