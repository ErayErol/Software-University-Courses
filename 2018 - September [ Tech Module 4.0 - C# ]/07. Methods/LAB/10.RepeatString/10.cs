using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatString(inputStr, count);
            Console.WriteLine(result);
        }

        static string RepeatString(string inputStr, int count)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(inputStr);
            }

            return result.ToString();
        }
    }
}