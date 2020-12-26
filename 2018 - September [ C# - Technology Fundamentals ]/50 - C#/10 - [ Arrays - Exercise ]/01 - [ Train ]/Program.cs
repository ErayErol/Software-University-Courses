using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());

            int[] wagons = new int[wagonsCount];
            for (int i = 0; i < wagonsCount; i++)
            {
                int peopleInWagonsCount = int.Parse(Console.ReadLine());
                wagons[i] = peopleInWagonsCount;
            }

            Console.WriteLine(string.Join(" ", wagons));
            Console.WriteLine(wagons.Sum());
        }
    }
}
