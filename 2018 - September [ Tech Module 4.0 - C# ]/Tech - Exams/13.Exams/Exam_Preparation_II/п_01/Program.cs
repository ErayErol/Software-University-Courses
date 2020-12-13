using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace п_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfTheMarathonInDays = int.Parse(Console.ReadLine());
            long numberOfRunners = long.Parse(Console.ReadLine());
            int averageNumberOfLapsEveryRunner = int.Parse(Console.ReadLine());
            long lenghtOfTheTrack = long.Parse(Console.ReadLine());
            long capacityOfTheTrack = long.Parse(Console.ReadLine());
            decimal amountOfMoney = decimal.Parse(Console.ReadLine());

            long maxRunners = capacityOfTheTrack * lengthOfTheMarathonInDays;
            if (maxRunners < numberOfRunners)
            {
                numberOfRunners = maxRunners;
            }

            long totalMeters = numberOfRunners * averageNumberOfLapsEveryRunner * lenghtOfTheTrack;
            long totalKm = totalMeters / 1000;
            decimal moneyRaised = totalKm * amountOfMoney;

            Console.WriteLine($"Money raised: {moneyRaised:F2}");
        }
    }
}
