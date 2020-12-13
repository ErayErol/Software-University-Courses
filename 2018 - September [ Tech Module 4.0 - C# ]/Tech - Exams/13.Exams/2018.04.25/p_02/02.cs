using System;
using System.Collections.Generic;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;
            List<string> words = new List<string>();

            while (input != "Visual Studio crash")
            {
                result += input + " ";
                input = Console.ReadLine();
            }

            string[] token = result.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < token.Length - 5; i++)
            {
                if (token[i] == "32656" && 
                    token[i + 1] == "19759" && 
                    token[i + 2] == "32763" && 
                    token[i + 3] == "0" &&
                    token[i + 5] == "0")
                {
                    string word = string.Empty;
                    int wordLength = int.Parse(token[i + 4]);
                    for (int j = i + 6; j < i + 6 + wordLength; j++)
                    {
                        word += (char)(int.Parse(token[j]));
                    }

                    words.Add(word);
                }
            }

            Console.WriteLine(string.Join("\n", words));
        }
    }
}