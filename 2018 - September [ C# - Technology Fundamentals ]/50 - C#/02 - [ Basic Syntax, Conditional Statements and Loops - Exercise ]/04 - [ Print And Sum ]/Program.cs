using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] arr = new int[end - start + 1];
            int counter = 0;
            for (int i = start; i <= end; i++)
            {
                arr[counter] = i;
                counter++;
                sum += i;
            }
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine($"\nSum: {sum}");
        }
    }
}
