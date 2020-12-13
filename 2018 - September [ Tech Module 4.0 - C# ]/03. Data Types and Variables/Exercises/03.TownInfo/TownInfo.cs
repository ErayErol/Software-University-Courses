namespace _03.TownInfo
{
    using System;

    class TownInfo
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            long population = int.Parse(Console.ReadLine());
            long area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {population} and area {area} square km.");
        }
    }
}