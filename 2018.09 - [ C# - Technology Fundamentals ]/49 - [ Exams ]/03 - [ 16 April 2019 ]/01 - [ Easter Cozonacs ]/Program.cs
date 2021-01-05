using System;

namespace EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceForOneKgFlour = double.Parse(Console.ReadLine());

            double priceForPackOfEggs = priceForOneKgFlour * 0.75;
            double priceForOneLiterOfMilk = priceForOneKgFlour + (priceForOneKgFlour * 0.25);
            double neededMilkForOneCozunac = priceForOneLiterOfMilk / 4;

            int totalColoredEggsCount = 0;

            int currentCozunacsCount = 0;

            while (budget >= priceForOneKgFlour + priceForPackOfEggs + neededMilkForOneCozunac)
            {
                budget -= priceForOneKgFlour + priceForPackOfEggs + neededMilkForOneCozunac;
                
                currentCozunacsCount++;
                totalColoredEggsCount += 3;
                
                if (currentCozunacsCount % 3 == 0)
                {
                    totalColoredEggsCount -= currentCozunacsCount - 2;
                }
            }

            Console.WriteLine($"You made {currentCozunacsCount} cozonacs! Now you have {totalColoredEggsCount} eggs and {budget:f2}BGN left.");
        }
    }
}
