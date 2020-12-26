using System;
using System.Collections.Generic;
using System.Text;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            List<char> letters = new List<char>();
            List<char> nums = new List<char>();
            List<char> others = new List<char>();


            for (int j = 0; j < str.Length; j++)
            {
                if ((str[j] >= 'a' && str[j] <= 'z') || (str[j] >= 'A' && str[j] <= 'Z'))
                {
                    letters.Add(str[j]);
                }
                else if (str[j] >= 48 && str[j] <= 57)
                {
                    nums.Add(str[j]);
                }
                else
                {
                    others.Add(str[j]);
                }
            }

            Console.WriteLine(string.Join("", nums));
            Console.WriteLine(string.Join("", letters));
            Console.WriteLine(string.Join("", others));
        }
    }
}
