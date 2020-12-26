using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine().ToLower();
            string word = Console.ReadLine();

            while (true)
            {
                int index = word.IndexOf(wordToRemove);

                if (index == -1)
                {
                    break;
                }

                string subString = word.Substring(index, wordToRemove.Length);
                word = word.Remove(index, subString.Length);
            }

            Console.WriteLine(word);
        }
    }
}
