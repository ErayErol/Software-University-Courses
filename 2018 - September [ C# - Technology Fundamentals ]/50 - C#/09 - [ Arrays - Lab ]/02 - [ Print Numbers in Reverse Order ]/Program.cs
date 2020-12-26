using System;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int[] numbers = new int[numbersCount];
            for (int i = 0; i < numbersCount; i++)
            {
                numbers[i] += int.Parse(Console.ReadLine());
            }
            
            Array.Reverse(numbers);
            foreach (int values in numbers)
            {
                Console.Write($"{values} ");
            }
        }
    }
}
