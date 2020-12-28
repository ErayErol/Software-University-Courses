using System;

namespace TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfAdventure = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayForPerson = double.Parse(Console.ReadLine());
            double foodPerDayForPerson = double.Parse(Console.ReadLine());

            double totalWater = waterPerDayForPerson * playersCount * daysOfAdventure;
            double totalFood = foodPerDayForPerson * playersCount * daysOfAdventure;

            for (int i = 1; i <= daysOfAdventure; i++)
            {
                double energyLost = double.Parse(Console.ReadLine());
                groupEnergy -= energyLost;
                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    break;
                }

                if (i % 2 == 0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    totalWater -= totalWater * 0.30;
                }

                if (i % 3 == 0)
                {
                    totalFood -= totalFood / playersCount;
                    groupEnergy += groupEnergy * 0.10;
                }

            }

            if (groupEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
        }
    }
}
