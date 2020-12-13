using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            var tokensCount = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int e = 0; e < words[i].Length; e++)
                {
                    if (!tokensCount.ContainsKey(words[i][e]))
                    {
                        tokensCount.Add(words[i][e], 0);
                    }

                    tokensCount[words[i][e]]++;
                }
            }

            foreach (var tokenCount in tokensCount)
            {
                Console.WriteLine($"{tokenCount.Key} -> {tokenCount.Value}");
            }
        }
    }
}