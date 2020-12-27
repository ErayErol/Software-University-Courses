using System;

namespace PrintPartOfAsciiTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingIndex = int.Parse(Console.ReadLine());
            int endingIndex = int.Parse(Console.ReadLine());

            for (int i = startingIndex; i <= endingIndex; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
