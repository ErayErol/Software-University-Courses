namespace _04.ArrayRotation
{
    using System;
    using System.Linq;

    class ArrayRotation
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            if (rotations >= numbers.Length)
            {
                rotations = rotations % numbers.Length;
            }

            int temp = 0;
            for (int i = 0; i < rotations; i++)
            {
                temp = numbers[0];
                for (int k = 0; k < numbers.Length - 1; k++)
                {
                    numbers[k] = numbers[k + 1];
                }
                numbers[numbers.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}