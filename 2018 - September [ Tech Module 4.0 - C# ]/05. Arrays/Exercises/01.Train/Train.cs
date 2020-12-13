namespace _01.Train
{
    using System;

    class Train
    {
        static void Main(string[] args)
        {
            int wagonCounts = int.Parse(Console.ReadLine());

            int[] arr = new int[wagonCounts];

            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int people = int.Parse(Console.ReadLine());
                arr[i] = people;
                sum += arr[i];
            }

            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(sum);
        }
    }
}