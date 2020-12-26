using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int totalDaysCounter = 0;
            int totalAmountOfSpices = 0;

            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    totalAmountOfSpices += startingYield - 26;
                    startingYield -= 10;
                    totalDaysCounter++;
                }
                Console.WriteLine(totalDaysCounter);
                Console.WriteLine(totalAmountOfSpices - 26);
            }
            else
            {
                Console.WriteLine(totalDaysCounter);
                Console.WriteLine(totalAmountOfSpices);
            }
        }
    }
}
