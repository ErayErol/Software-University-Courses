using System;

namespace SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int charsCount = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < charsCount; i++)
            {
                char ch = char.Parse(Console.ReadLine());
                sum += ch;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
