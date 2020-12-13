namespace _06_Solution
{
    using System.IO;

    class StartUp
    {
        static void Main(string[] args)
        {
            long bytes = 0;
            string[] files = Directory.GetFiles("TestFolder");
            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                using (var streamReadFile = File.OpenRead(file))
                {
                    bytes += streamReadFile.Length;
                }
            }

            using (var writer = new StreamWriter("../../../Output.txt"))
            {
                var result = ConvertBytesToMegabytes(bytes);
                writer.WriteLine($"{result:f14}");
            }
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}