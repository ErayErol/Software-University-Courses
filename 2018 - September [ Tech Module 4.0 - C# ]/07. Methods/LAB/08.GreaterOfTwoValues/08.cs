using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string max = GetMax(first, second);
                Console.WriteLine(max);
            }

        }

        static int GetMax(int first, int second)
        {
            int bigger = 0;
            if (first >= second)
            {
                bigger = first;
            }
            else
            {
                bigger = second;
            }

            return bigger;
        }

        static char GetMax(char first, char second)
        {
            char bigger = ' ';

            if (first >= second)
            {
                bigger = first;
            }
            else
            {
                bigger = second;
            }

            return bigger;
        }

        static string GetMax(string first, string second)
        {
            string bigger = null;
            if (first.CompareTo(second) >= 0)
            {
                bigger = first;
            }
            else
            {
                bigger = second;
            }

            return bigger;
        }
    }
}
