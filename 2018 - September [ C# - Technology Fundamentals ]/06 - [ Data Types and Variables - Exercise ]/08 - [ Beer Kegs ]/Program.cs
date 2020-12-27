using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            double maxSize = double.MinValue;
            string modelOfTheBiggestKeg = string.Empty;
            
            for (int i = 1; i <= counter; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double kegVolume = Math.PI * (kegRadius * kegRadius) * kegHeight;
                if (kegVolume > maxSize)
                {
                    modelOfTheBiggestKeg = kegModel;
                    maxSize = kegVolume;
                }
            }
            Console.WriteLine(modelOfTheBiggestKeg);
        }
    }
}
