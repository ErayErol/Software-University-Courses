namespace _02_Solution
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main(string[] args)
        {
            using(var reader = new StreamReader("Input.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    var lineNum = 1;
                    while (reader.EndOfStream == false)
                    {
                        var line = reader.ReadLine();
                        writer.WriteLine($"{lineNum}.\t{line}");
                        Console.WriteLine($"{lineNum}.\t{line}");
                        lineNum++;
                    }
                }
            }
        }
    }
}
