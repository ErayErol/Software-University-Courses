using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                var letters = str.ToCharArray();
                char letter = (char)(letters[i] + 3);
                newStr += letter;
            }

            Console.WriteLine(newStr);
        }
    }
}
