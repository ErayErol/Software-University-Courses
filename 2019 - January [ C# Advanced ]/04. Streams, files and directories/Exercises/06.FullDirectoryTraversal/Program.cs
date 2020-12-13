namespace _06.FullDirectoryTraversal
{
    using System.IO.Compression;

    class Program
    {
        static void Main(string[] args)
        {
            string startPath = "../../";
            string zipPath = "../../../result.zip";
            string extractPath = "../../../ExtractZIP";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}