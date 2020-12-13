namespace _03.WordCount
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            using (var readerWords = new StreamReader("words.txt"))
            {
                var wordCount = new Dictionary<string, int>();
                var words = new List<string>();

                while (readerWords.EndOfStream == false)
                {
                    var word = readerWords
                                .ReadLine()
                                .ToLower();

                    words.Add(word);
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

                    using (var writer = new StreamWriter("../../../actualResult.txt"))
                    {
                        foreach (var word in wordCount.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }

                    using (var actualResults = new StreamReader("../../../actualResult.txt"))
                    {
                        using (var expectedResults = new StreamReader("../../../expectedResult.txt"))
                        {
                            var equal = true;
                            while (actualResults.EndOfStream == false && expectedResults.EndOfStream)
                            {
                                if (actualResults.ReadLine() != expectedResults.ReadLine())
                                {
                                    equal = false;
                                }
                            }


                            using (var writer = new StreamWriter("../../../Output.txt"))
                            {
                                if (equal)
                                {
                                    writer.WriteLine("Equal");
                                }
                                else
                                {
                                    writer.WriteLine("Not equal");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}