using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToAFile = Console.ReadLine();

            int index = pathToAFile.LastIndexOf('\\');
            pathToAFile = pathToAFile.Substring(index + 1);

            string[] file = pathToAFile.Split('.');
            string name = file[0];
            string extension = file[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}