namespace _01_Solution
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("Input.txt"))
            {
                var counter = 0;
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine();
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}