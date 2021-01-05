using System;

namespace RageExpensesV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadsets = lostGames / 2;
            int trashedMouses = lostGames / 3;
            int trashedKeyboards = lostGames / 6;
            int trashedDisplays = lostGames / 12;

            double totalMoney = (trashedHeadsets * headsetPrice) +
                                (trashedMouses * mousePrice) +
                                (trashedKeyboards * keyboardPrice) +
                                (trashedDisplays * displayPrice);
            
            Console.WriteLine($"Rage expenses: {totalMoney:f2} lv.");
        }
    }
}
