using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] characters = Console.ReadLine().Split();

            PrintSumBetweenCharacters(characters);
        }

        private static void PrintSumBetweenCharacters(string[] characters)
        {
            string firstText = characters[0];
            string secondText = characters[1];

            int minLength;
            int maxLength;
            string longestLength;

            if (firstText.Length > secondText.Length)
            {
                maxLength = firstText.Length;
                minLength = secondText.Length;
                longestLength = firstText;
            }
            else if (firstText.Length < secondText.Length)
            {
                maxLength = secondText.Length;
                minLength = firstText.Length;
                longestLength = secondText;
            }
            else
            {
                minLength = firstText.Length;
                longestLength = secondText;
            }

            long sum = 0;
            for (int i = 0; i < minLength; i++)
            {
                long multiply = firstText[i] * secondText[i];
                sum = sum + multiply;
            }

            for (int i = minLength; i < longestLength.Length; i++)
            {
                sum = sum + longestLength[i];
            }

            Console.WriteLine(sum);
        }
    }
}