using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            CharactersInRange(start, end);
        }

        static void CharactersInRange(char start, char end)
        {
            for (int i = Math.Min(start, end) + 1; i < Math.Max(start, end); i++)
            {
                Console.Write((char)i + " ");
            }
        }

    }
}
