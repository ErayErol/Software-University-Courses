namespace _07.MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            int startIndex = 0;
            int currentLength = 1;
            int maxStart = 0;
            int maxLength = 1;

            for (int index = 1; index < numbers.Length; index++)
            {
                if (numbers[index] == numbers[index - 1])
                {
                    currentLength++;

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        maxStart = startIndex;
                    }
                }
                else
                {
                    currentLength = 1;
                    startIndex = index;
                }
            }

            for (int index = maxStart; index < maxStart + maxLength; index++)
            {
                Console.Write(numbers[index] + " ");
            }

            Console.WriteLine();
        }
    }
}