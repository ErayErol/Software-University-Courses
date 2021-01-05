using System;

namespace BiscuitsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int amountOfBiscuitsForCompete = int.Parse(Console.ReadLine());

            double totalProduced = 0;
            for (int i = 0; i < 30; i++)
            {

                if (i % 3 == 0)
                {
                    totalProduced += Math.Floor(0.75 * biscuitsPerWorker * workersCount);
                }
                else
                {
                    totalProduced += biscuitsPerWorker * workersCount;
                }
            }

            double diff = Math.Abs(totalProduced - amountOfBiscuitsForCompete);
            double percent = (diff / amountOfBiscuitsForCompete) * 100;

            Console.WriteLine($"You have produced {totalProduced} biscuits for the past month.");

            if (totalProduced >= amountOfBiscuitsForCompete)
            {
                Console.WriteLine($"You produce {percent:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percent:f2} percent less biscuits.");
            }
        }
    }
}
