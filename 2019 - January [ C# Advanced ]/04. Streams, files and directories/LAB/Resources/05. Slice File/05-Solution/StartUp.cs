namespace _05_Solution
{
    using System;
    using System.IO;

    class StartUp
    {
        static void Main(string[] args)
        {
            const int parts = 4;

            using (var streamReadFile = File.OpenRead("sliceMe.txt"))
            {
                long pieceSize = (long)Math.Ceiling((double)streamReadFile.Length / parts);
                byte[] buffer = new byte[pieceSize];

                for (int i = 1; i <= parts; i++)
                {
                    using (var streamCreateFile = File.Create($"../../../Part-{i}.txt"))
                    {
                        streamReadFile.Read(buffer, 0, buffer.Length);
                        streamCreateFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}