using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            GetRange(first, second);
        }

        private static void GetRange(char first, char second)
        {
            List<char> token = new List<char>();
            char start = '\0';
            char finish = '\0';
            if (first > second)
            {
                start = second;
                finish = first;
            }
            else
            {
                start = first;
                finish = second;
            }

            for (char i = ++start; i < finish; i++)
            {
                token.Add(i);
            }

            Console.WriteLine(string.Join(" ", token));
        }
    }
}
