using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime timeOfLeavingSoftUni = DateTime.Parse(Console.ReadLine());
            int stepsTaken = int.Parse(Console.ReadLine()) % 86400;
            int stepsPerSec = int.Parse(Console.ReadLine()) % 86400;

            int timeInTravel = stepsTaken * stepsPerSec;
            DateTime result = timeOfLeavingSoftUni.AddSeconds(timeInTravel);

            Console.WriteLine($"Time Arrival: {result:HH:mm:ss}");
        }
    }
}