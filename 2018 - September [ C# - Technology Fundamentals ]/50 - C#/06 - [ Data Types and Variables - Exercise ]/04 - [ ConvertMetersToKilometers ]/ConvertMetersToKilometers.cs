namespace _04.ConvertMetersToKilometers
{
    using System;

    class ConvertMetersToKilometers
    {
        static void Main(string[] args)
        {
            double distanceInMeters = double.Parse(Console.ReadLine());

            double distanceInKilometres = distanceInMeters / 1000.0;

            Console.WriteLine($"{distanceInKilometres:F2}");
        }
    }
}