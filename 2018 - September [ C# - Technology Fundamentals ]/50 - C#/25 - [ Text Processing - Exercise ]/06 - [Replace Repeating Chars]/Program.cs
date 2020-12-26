using System;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    str = str.Remove(i, 1);
                    i = -1;
                }
            }

            Console.WriteLine(str);
        }
    }
}
