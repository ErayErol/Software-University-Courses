using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            long wingFlaps = long.Parse(Console.ReadLine());
            decimal theDistanceTheHornetTravelsFor1000WingFlaps = decimal.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());

            decimal metersTraveled = (wingFlaps / 1000.0m) * theDistanceTheHornetTravelsFor1000WingFlaps;
            Console.WriteLine($"{metersTraveled:F2} m.");

            decimal secondsWithoutRest = wingFlaps / 100.0m;
            long secondsWithRest = (wingFlaps / endurance) * 5;
            decimal secondsPassed = secondsWithoutRest + secondsWithRest;
            Console.WriteLine($"{secondsPassed} s.");
        }
    }
}
