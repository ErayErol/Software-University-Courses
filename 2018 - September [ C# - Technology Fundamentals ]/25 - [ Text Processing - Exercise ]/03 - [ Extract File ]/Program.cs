using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int slashIndex = filePath.LastIndexOf('\\');
            int dotIndex = filePath.LastIndexOf('.');

            string fileName = filePath.Substring(slashIndex + 1, dotIndex - slashIndex - 1);
            string fileExtension = filePath.Substring(dotIndex + 1, filePath.Length - dotIndex - 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
