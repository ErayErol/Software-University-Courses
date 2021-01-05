using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch = char.Parse(Console.ReadLine());
            if (ch >= 'A' && ch <= 'Z')
            {
                Console.WriteLine("upper-case");
            }
            else if (ch >= 'a' && ch <= 'z')
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
