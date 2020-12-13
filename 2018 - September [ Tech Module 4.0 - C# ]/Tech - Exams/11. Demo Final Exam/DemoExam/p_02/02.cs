using System;
using System.Text;
using System.Text.RegularExpressions;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedText = Console.ReadLine();
            string[] substrings = Console.ReadLine().Split();

            string pattern = @"^[d-z\{\}\|\#]+$";
            Match regex = Regex.Match(encryptedText, pattern);

            if (regex.Success)
            {
                int reducing = 3;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < encryptedText.Length; i++)
                {
                    int index = encryptedText[i] - reducing;
                    sb.Append((char) index);
                }

                string first = substrings[0];
                string second = substrings[1];

                string result = Regex.Replace(sb.ToString(), first, second);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}