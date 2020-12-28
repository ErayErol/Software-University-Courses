using System;

namespace DistanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double oneStepLength = double.Parse(Console.ReadLine());
            int neededDistance = int.Parse(Console.ReadLine());

            double totalDistance = 0;
            for (int i = 1; i <= stepsMade; i++)
            {
                double currDistance = oneStepLength * 1;
                
                if (i % 5 == 0)
                {
                    currDistance -= currDistance * 0.30;
                }

                totalDistance += currDistance;
            }
            totalDistance /= 100;
            double percent = (totalDistance / neededDistance) * 100;
            Console.WriteLine($"You travelled {percent:f2}% of the distance!");
        }
    }
}
