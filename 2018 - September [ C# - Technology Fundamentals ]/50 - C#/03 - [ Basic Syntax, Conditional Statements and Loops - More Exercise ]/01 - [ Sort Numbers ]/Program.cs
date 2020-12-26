using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int maxNumber = Math.Max(Math.Max(firstNumber, secondNumber), thirdNumber);
            int minNumber = Math.Min(Math.Min(firstNumber, secondNumber), thirdNumber);
            int averageNumber = (firstNumber + secondNumber + thirdNumber) - (maxNumber + minNumber);

            Console.WriteLine(maxNumber);
            Console.WriteLine(averageNumber);
            Console.WriteLine(minNumber);
        }
    }
}
