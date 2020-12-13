using System;
using System.Collections.Generic;
using System.Linq;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, List<string>>();

            string[] wordsDefinitions = Console.ReadLine().Split(" | ");
            for (int i = 0; i < wordsDefinitions.Length; i++)
            {
                string[] wordsDefinitionsSplitted = wordsDefinitions[i].Split(": ");
                string word = wordsDefinitionsSplitted[0];
                string definition = wordsDefinitionsSplitted[1];

                if (dic.ContainsKey(word) == false)
                {
                    dic.Add(word, new List<string>());
                }
                dic[word].Add(definition);
            }

            string[] words = Console.ReadLine().Split(" | ");
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];

                if (dic.ContainsKey(currentWord))
                {
                    foreach (var word in dic.Where(w => w.Key == currentWord))
                    {
                        Console.WriteLine(word.Key);
                        foreach (var definition in word.Value.OrderByDescending(d => d.Length))
                        {
                            Console.WriteLine($" -{definition}");
                        }
                    }
                }
            }

            string listOrEnd = Console.ReadLine();
            if (listOrEnd == "List")
            {
                Console.Write($"{string.Join(" ", dic.Keys.OrderBy(w => w))}");
                Console.WriteLine();
            }
        }
    }
}