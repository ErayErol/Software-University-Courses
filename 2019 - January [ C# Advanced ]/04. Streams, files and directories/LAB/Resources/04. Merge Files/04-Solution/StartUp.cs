namespace _04_Solution
{
    using System.Collections.Generic;
    using System.IO;

    class StartUp
    {
        static void Main(string[] args)
        {
            var merge = new List<string>();
            using (var readerOne = new StreamReader("FileOne.txt"))
            {
                using (var readerTwo = new StreamReader("FileTwo.txt"))
                {
                    while (readerOne.EndOfStream == false && readerTwo.EndOfStream == false)
                    {
                        var line1 = readerOne.ReadLine();
                        var line2 = readerTwo.ReadLine();

                        merge.Add(line1);
                        merge.Add(line2);
                    }

                    using (var writer = new StreamWriter("../../../Output.txt"))
                    {
                        foreach (var line in merge)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}