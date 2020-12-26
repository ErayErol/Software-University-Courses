using System;

namespace ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal metersToKilometers = meters / 1000.0m;
            Console.WriteLine($"{metersToKilometers:f2}");
        }
    }
}
