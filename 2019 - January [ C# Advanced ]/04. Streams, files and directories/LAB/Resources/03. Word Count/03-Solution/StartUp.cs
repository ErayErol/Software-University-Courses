namespace _03_Solution
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var readerWords = new StreamReader("words.txt"))
            {
                var wordCount = new Dictionary<string, int>();
                var words = readerWords
                            .ReadLine()
                            .ToLower()
                            .Split()
                            .ToList();

                foreach (var word in words)
                {
                    wordCount[word] = 0;
                }

                using (var readerText = new StreamReader("text.txt"))
                {
                    while (readerText.EndOfStream == false)
                    {
                        var line = readerText.ReadLine();

                        foreach (var word in words)
                        {
                            if (line.ToLower().Contains(word))
                            {
                                wordCount[word]++;
                            }
                        }
                    }

                    using (var writer = new StreamWriter("../../../Output.txt"))
                    {
                        foreach (var word in wordCount.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}