namespace _04.CopyBinaryFile
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            //File.Copy("../../../copyMe.png", "../../../copied.png"); => Solution with File.Copy

            using (var reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream("../../../copied.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int byteSize = reader.Read(buffer, 0, buffer.Length);

                        if (byteSize < 1)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, byteSize);
                    }
                }
            }
        }
    }
}