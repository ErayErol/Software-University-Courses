using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numsOfWord = int.Parse(Console.ReadLine());
            var wordSynonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < numsOfWord; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordSynonyms.ContainsKey(word))
                {
                    wordSynonyms.Add(word, new List<string>());
                }

                wordSynonyms[word].Add(synonym);
            }

            foreach (var wordSynonym in wordSynonyms)
            {
                Console.WriteLine($"{wordSynonym.Key} - {string.Join(", ", wordSynonym.Value)}");
            }
        }
    }
}