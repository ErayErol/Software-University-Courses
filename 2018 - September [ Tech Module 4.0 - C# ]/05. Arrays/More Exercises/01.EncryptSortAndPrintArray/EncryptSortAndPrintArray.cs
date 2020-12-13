namespace _01.EncryptSortAndPrintArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EncryptSortAndPrintArray
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                var character = input.ToCharArray();

                int sum = 0;

                for (int j = 0; j < character.Length; j++)
                {
                    if (character[j] == 'a' || character[j] == 'e' || character[j] == 'u' || character[j] == 'i' || character[j] == 'o' ||
                        character[j] == 'A' || character[j] == 'E' || character[j] == 'U' || character[j] == 'I' || character[j] == 'O')
                    {
                        sum = sum + (character[j] * input.Length);
                    }
                    else
                    {
                        sum = sum + (character[j] / input.Length);
                    }
                }

                numbers.Add(sum);
            }

            foreach (var num in numbers.OrderBy(n => n))
            {
                Console.WriteLine(num);
            }
        }
    }
}