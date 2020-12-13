namespace _01.EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string specialSymbols = "-,.!?";
            char replaceSymbol = '@';

            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    var counter = 0;
                    while (reader.EndOfStream == false)
                    {
                        var line = reader.ReadLine();
                        if (counter % 2 == 0)
                        {
                            foreach (var symbol in specialSymbols)
                            {
                                if (line.Contains(symbol))
                                {
                                    line = line.Replace(symbol, replaceSymbol);
                                }
                            }

                            var reverseLine = line.ToString().Split().ToList();
                            reverseLine.Reverse();
                            writer.WriteLine(String.Join(" ", reverseLine));
                        }
                        counter++;
                    }
                }
            }
        }
    }
}