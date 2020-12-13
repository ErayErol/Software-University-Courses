namespace _05.DirectoryTraversal
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../");
            var filesInfo = new Dictionary<string, Dictionary<string, double>>();

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                double documentKb = fileInfo.Length / 1024;
                var documentType = file.Substring(file.LastIndexOf("."));
                var documentName = file.Substring(file.LastIndexOf("/") + 1);

                if (filesInfo.ContainsKey(documentType) == false)
                {
                    filesInfo.Add(documentType, new Dictionary<string, double>());
                }
                filesInfo[documentType].Add(documentName, documentKb);
            }

            using (var writer = new StreamWriter("../../../report.txt"))
            {
                var sortedFilesInfo = filesInfo
                    .OrderByDescending(z => z.Value.Count)
                    .ThenBy(z => z.Key)
                    .ToDictionary(z => z.Key, z => z.Value);

                foreach (var fileInfo in sortedFilesInfo)
                {
                    writer.WriteLine(fileInfo.Key);

                    foreach (var file in fileInfo.Value.OrderBy(z => z.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value:F3}kb");
                    }
                }
            }
        }
    }
}