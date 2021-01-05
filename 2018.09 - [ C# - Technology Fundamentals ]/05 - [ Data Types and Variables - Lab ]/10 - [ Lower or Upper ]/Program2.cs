using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch = char.Parse(Console.ReadLine());
            if (ch >= 65 && ch <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else if (ch >= 97 && ch <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
