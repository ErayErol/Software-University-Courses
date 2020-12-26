using System;

namespace DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int linesNumber = int.Parse(Console.ReadLine());
            
            string decryptedMessage = string.Empty;
            for (int i = 1; i <= linesNumber; i++)
            {
                char ch = char.Parse(Console.ReadLine());
                ch += (char)key;
                decryptedMessage += ch;
            }
            Console.WriteLine(decryptedMessage);
        }
    }
}
