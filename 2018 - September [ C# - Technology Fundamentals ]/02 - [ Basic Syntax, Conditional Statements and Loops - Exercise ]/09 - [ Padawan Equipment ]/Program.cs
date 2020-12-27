using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsabersPricePerOne = double.Parse(Console.ReadLine());
            double robesPricePerOne = double.Parse(Console.ReadLine());
            double beltsPricePerOne = double.Parse(Console.ReadLine());

            int freeBeltsCount = 0;
            for (int i = 1; i <= studentsCount; i++)
            {
                if (i % 6 == 0)
                {
                    freeBeltsCount++;
                }
            }

            double additionalLightsabers = Math.Ceiling(studentsCount * 0.10);
            double lightsabersTotalPrice = lightsabersPricePerOne * (studentsCount + additionalLightsabers);
            double robesTotalPrice = robesPricePerOne * studentsCount;
            double beltsTotalPrice = beltsPricePerOne * (studentsCount - freeBeltsCount);

            double equipmentTotalPrice = lightsabersTotalPrice + robesTotalPrice + beltsTotalPrice;

            if (money >= equipmentTotalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmentTotalPrice:f2}lv.");
            }
            else
            {
                double neededMoney = equipmentTotalPrice - money;
                Console.WriteLine($"Ivan Cho will need {neededMoney:f2}lv more.");
            }
        }
    }
}
