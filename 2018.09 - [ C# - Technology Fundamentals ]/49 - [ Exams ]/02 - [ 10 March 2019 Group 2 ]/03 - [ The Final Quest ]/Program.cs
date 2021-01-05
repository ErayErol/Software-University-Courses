using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console
                .ReadLine()
                .Split()
                .ToList();

            string input;

            int index = 0;
            string firstWord = string.Empty;
            string secondWord = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                List<string> commands = input
                    .Split()
                    .ToList();

                switch (commands[0])
                {
                    case "Delete":
                        index = int.Parse(commands[1]);

                        DeletingWord(words, index);
                        break;
                    case "Swap":
                        firstWord = commands[1];
                        secondWord = commands[2];

                        SwappingTwoWords(words, firstWord, secondWord);
                        break;
                    case "Put":
                        firstWord = commands[1];
                        index = int.Parse(commands[2]);

                        PuttingWord(words, firstWord, index);
                        break;
                    case "Sort":
                        SortingWords(words);
                        break;
                    case "Replace":
                        firstWord = commands[1];
                        secondWord = commands[2];

                        ReplacingWords(words, firstWord, secondWord);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }

        static void DeletingWord(List<string> words, int index)
        {
            if (index >= 0 && index < words.Count)
            {
                words.RemoveAt(index + 1);
            }
        }

        static void SwappingTwoWords(List<string> words, string firstWord, string secondWord)
        {
            if ((words.Contains(firstWord)) && (words.Contains(secondWord)))
            {
                int firstIndex = words.IndexOf(firstWord);
                int secondIndex = words.IndexOf(secondWord);

                string temp = words[firstIndex];

                words[firstIndex] = secondWord;
                words[secondIndex] = temp;
            }
        }

        static void PuttingWord(List<string> words, string firstWord, int index)
        {
            if (index >= 0 && index <= words.Count)
            {
                words.Insert(index - 1, firstWord);
            }
        }

        static void SortingWords(List<string> words)
        {
            words.Sort((x, y) => y.CompareTo(x));
        }

        static void ReplacingWords(List<string> words, string firstWord, string secondWord)
        {
            if (words.Contains(secondWord))
            {
                int secondIndex = words.IndexOf(secondWord);

                words[secondIndex] = firstWord;
            }
        }
    }
}
