using System;

namespace _02.CharsToString
{
    class CharsToString
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());

            Console.WriteLine($"{firstLetter}{secondLetter}{thirdLetter}");
        }
    }
}