namespace _08.CondenseArrayToNumber
{
    using System;
    using System.Linq;

    class CondenseArrayToNumber
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var counter = input.Length;

            while (counter > 1)
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    input[i] = input[i] + input[i + 1];
                }
                counter--;
            }

            Console.WriteLine(input[0]);
        }
    }
}