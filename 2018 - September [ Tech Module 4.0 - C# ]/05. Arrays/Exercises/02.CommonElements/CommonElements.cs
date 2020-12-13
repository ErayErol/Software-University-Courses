namespace _02.CommonElements
{
    using System;
    using System.Linq;

    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] words1 = Console.ReadLine().Split();
            string[] words2 = Console.ReadLine().Split();

            for (int i = 0; i < words2.Length; i++)
            {
                if (words1.Contains(words2[i])) // words2[i] съдържа ли се в words1
                {
                    Console.Write(words2[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}