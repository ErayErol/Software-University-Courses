namespace _03.CustomMinFunction
{
    using System;
    using System.Linq;

    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            // 1 4 3 2 1 7 13
            Action<int> print = Console.WriteLine;
            Func<int[], int> minNumFunc = inputNums =>
            {
                int minValue = int.MaxValue;
                foreach (var value in inputNums)
                {
                    if (value < minValue)
                    {
                        minValue = value;
                    }
                }

                return minValue;
            };

            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            print(minNumFunc(nums));
        }
    }
}