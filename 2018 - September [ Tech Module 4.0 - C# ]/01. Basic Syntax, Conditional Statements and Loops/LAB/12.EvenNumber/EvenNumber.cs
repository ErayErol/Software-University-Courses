namespace _12.EvenNumber
{
    using System;

    class EvenNumber
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            bool isEven = number % 2 == 1;

            while (isEven)
            {
                Console.WriteLine("Please write an even number.");
                number = Math.Abs(int.Parse(Console.ReadLine()));
                isEven = number % 2 == 1;
            }

            Console.WriteLine($"The number is: {number}");
        }
    }
}