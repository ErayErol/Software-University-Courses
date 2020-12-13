namespace _02.PrintNumbersInReverseOrder
{
    using System;

    class PrintNumbersInReverseOrder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                Console.Write(nums[i]);
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}