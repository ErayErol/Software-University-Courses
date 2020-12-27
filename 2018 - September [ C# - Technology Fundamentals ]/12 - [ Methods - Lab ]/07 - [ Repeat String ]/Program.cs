using System;
using System.Linq;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int repeatingsCount = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatingString(str, repeatingsCount));
        }

        static string RepeatingString(string str, int repeatingsCount)
        {
            string result = string.Join("", Enumerable.Repeat(str, repeatingsCount));
            return result;
        }
    }
}
