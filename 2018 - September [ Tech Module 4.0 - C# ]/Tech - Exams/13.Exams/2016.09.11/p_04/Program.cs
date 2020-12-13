using System;
using System.Collections.Generic;
using System.Linq;

namespace p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootFilenameExtensionFilesize = new Dictionary<string, Dictionary<string, int>>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string commands = Console.ReadLine();

                int indexForRoot = commands.IndexOf('\\');
                char[] rootSymbols = commands.Take(indexForRoot).ToArray();
                string root = new string(rootSymbols);

                int lastIndex = commands.LastIndexOf('\\');
                char[] filenameExtensionFilesize = commands.Skip(lastIndex + 1).Take(commands.Length).ToArray();
                string[] filenameExtensionFilesizeSplited = new string(filenameExtensionFilesize).Trim().Split(';');

                int filesize = int.Parse(filenameExtensionFilesizeSplited.Last());

                if (rootFilenameExtensionFilesize.ContainsKey(root) == false)
                {
                    rootFilenameExtensionFilesize.Add(root, new Dictionary<string, int>());
                    rootFilenameExtensionFilesize[root].Add(filenameExtensionFilesizeSplited[0], 0);
                }

                rootFilenameExtensionFilesize[root][filenameExtensionFilesizeSplited[0]] = filesize;
            }

            string[] command = Console.ReadLine().Split();
            string extensionForResult = command[0];
            string rootForResult = command[2];

            bool isValid = true;

            foreach (var kvp in rootFilenameExtensionFilesize.Where(a => a.Key == rootForResult))
            {
                foreach (var result in kvp.Value.Where(a => a.Key.Contains(extensionForResult)).OrderByDescending(f => f.Value).ThenBy(f => f.Key))
                {
                    isValid = false;
                    Console.WriteLine($"{result.Key} - {result.Value} KB");
                }
            }

            if (isValid)
            {
                Console.WriteLine("No");
            }
        }
    }
}