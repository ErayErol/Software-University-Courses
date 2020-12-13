namespace _01.SumDigits
{
    using System;

    class SumDigits
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            numbers.ToCharArray();

            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i] - '0';
            }

            Console.WriteLine(sum);
        }
    }
}