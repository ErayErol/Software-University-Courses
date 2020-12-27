using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console
                .ReadLine()
                .Split()
                .ToList();

            string firstWord = words[0];
            string secondWord = words[1];

            int min = Math.Min(firstWord.Length, secondWord.Length);
            int max = Math.Max(firstWord.Length, secondWord.Length);
            
            int sum = 0;
            for (int i = 0; i < min; i++)
            {
                sum += firstWord[i] * secondWord[i];
            }

            if (firstWord.Length != secondWord.Length)
            {
                string longerInput = firstWord.Length > secondWord.Length ? longerInput = firstWord : longerInput = secondWord;
               
                for (int i = min; i < max; i++)
                {
                    sum += longerInput[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
