namespace _02.SumNumbers
{
    using System;
    using System.Linq;

    class SumNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(numbers.Length + "\r\n" + numbers.Sum());
        }
    }
}