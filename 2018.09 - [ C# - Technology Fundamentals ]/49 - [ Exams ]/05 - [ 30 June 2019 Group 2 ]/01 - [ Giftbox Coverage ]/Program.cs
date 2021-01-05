using System;

namespace GiftboxCoverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int sheetsCount = int.Parse(Console.ReadLine());
            double sheetArea = double.Parse(Console.ReadLine());

            double boxArea = 6 * (Math.Pow(sideSize, 2));
            double paperArea = 0;

            for (int i = 1; i <= sheetsCount; i++)
            {
                double calculatePaperArea = 1 * sheetArea;
                if (i % 3 == 0)
                {
                    calculatePaperArea = sheetArea * 0.25;
                }
                paperArea += calculatePaperArea;
            }

            double percent = (paperArea / boxArea) * 100;
            Console.WriteLine($"You can cover {percent:f2}% of the box.");
        }
    }
}
