using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder newText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int index = text[i] + 3;

                newText.Append((char)index);
            }

            Console.WriteLine(newText.ToString());
        }
    }
}