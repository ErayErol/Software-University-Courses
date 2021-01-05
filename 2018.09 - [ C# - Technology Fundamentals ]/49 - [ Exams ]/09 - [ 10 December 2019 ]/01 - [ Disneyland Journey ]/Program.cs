using System;

namespace DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyPrice = double.Parse(Console.ReadLine());
            int monthsCount = int.Parse(Console.ReadLine());

            double savedMoney = 0;
            
            for (int i = 1; i <= monthsCount; i++)
            {
                if ((i % 2 != 0) && (i != 1))
                {
                    savedMoney -= savedMoney * 0.16;
                }

                if (i % 4 == 0)
                {
                    savedMoney += savedMoney * 0.25;
                }

                savedMoney += journeyPrice * 0.25;
            }

            if (savedMoney >= journeyPrice)
            {
                double leftMoney = savedMoney - journeyPrice;
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {leftMoney:f2}lv. for souvenirs.");
            }
            else
            {
                double neededMoney = journeyPrice - savedMoney;
                Console.WriteLine($"Sorry. You need {neededMoney:f2}lv. more.");
            }
        }
    }
}
