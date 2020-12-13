namespace _02.LineNumbers
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    var counter = 0;
                    while (reader.EndOfStream == false)
                    {
                        counter++;
                        var lettersCount = 0;
                        var punctuationCount = 0;

                        var line = reader.ReadLine();

                        foreach (var token in line)
                        {
                            if (char.IsLetter(token))
                            {
                                lettersCount++;
                            }
                            else if (char.IsPunctuation(token))
                            {
                                punctuationCount++;
                            }
                        }

                        writer.WriteLine($"Line {counter}: {line} ({lettersCount})({punctuationCount})");
                    }
                }
            }
        }
    }
}