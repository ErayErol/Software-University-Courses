using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();

            List<int> sumOfDigits = new List<int>();
            
            List<string> letters = new List<string>();

            CountingSumOfTheDigits(numbers, sumOfDigits);
            
            AddingEveryCharToNewList(letters, text);
            
            Console.WriteLine(FindingTheMessage(sumOfDigits, letters));
        }

        static void CountingSumOfTheDigits(List<int> numbers, List<int> sumOfDigits)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int currSum = 0;
                int copy = numbers[i];

                while (copy != 0)
                {
                    int digit = copy % 10;
                    currSum += digit;
                    copy /= 10;
                }

                sumOfDigits.Add(currSum);
            }
        }

        static void AddingEveryCharToNewList(List<string> letters, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                letters.Add(text[i].ToString());
            }
        }

        static string FindingTheMessage(List<int> sumOfDigits, List<string> letters)
        {
            string result = string.Empty;
            
            for (int i = 0; i < sumOfDigits.Count; i++)
            {
                int index = 0;

                if (sumOfDigits[i] >= letters.Count)
                {
                    index = sumOfDigits[i] - letters.Count;
                    result += letters[index];
                }
                else
                {
                    result += letters[sumOfDigits[i]];
                }

                letters.RemoveAt(index);
            }

            return result;
        }
    }
}
