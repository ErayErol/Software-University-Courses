using System;
using System.Collections.Generic;
using System.Linq;

namespace midExamSundayFundamentalsSoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studsCount = int.Parse(Console.ReadLine());

            int hoursCounter = 0;

            while (studsCount > 0)
            {
                studsCount -= firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
                hoursCounter++;
                if (hoursCounter % 4 == 0)
                {
                    hoursCounter++;
                }
            }

            Console.WriteLine($"Time needed: {hoursCounter}h.");
        }
    }
}
