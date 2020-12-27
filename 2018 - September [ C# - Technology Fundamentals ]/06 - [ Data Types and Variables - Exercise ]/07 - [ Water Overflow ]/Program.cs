using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            double totalWaterCount = 0;
            for (int i = 0; i < numberOfLines; i++)
            {
                double water = double.Parse(Console.ReadLine());
                if (water + totalWaterCount > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    totalWaterCount += water;
                }
            }
            Console.WriteLine(totalWaterCount);
        }
    }
}
