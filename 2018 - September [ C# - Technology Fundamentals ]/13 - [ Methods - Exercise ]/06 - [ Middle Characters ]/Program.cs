using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Console.WriteLine(MiddleElement(str));
        }

        static string MiddleElement(string str)
        {
            string middle = string.Empty;
            
            if (str.Length % 2 == 0)
            {
                middle = str[(str.Length / 2) - 1] + str[str.Length / 2].ToString();
            }
            else
            {
                middle = str[str.Length / 2].ToString();
            }
            
            return middle;
        }
    }
}
