using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headSetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadSetsCount = 0;
            int trashedMouseCount = 0;
            int trashedKeyboardCount = 0;
            int trashedDisplayCount = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                int crashedTheSame = 0;
                if (i % 2 == 0)
                {
                    trashedHeadSetsCount++;
                }
                if (i % 3 == 0)
                {
                    trashedMouseCount++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    crashedTheSame++;
                }

                if (crashedTheSame == 1)
                {
                    trashedKeyboardCount++;
                    if (trashedKeyboardCount > 0 && trashedKeyboardCount % 2 == 0)
                    {
                        trashedDisplayCount++;
                    }
                }

            }

            double totalExpenses = trashedHeadSetsCount * headSetPrice + trashedMouseCount * mousePrice + trashedKeyboardCount * keyboardPrice + trashedDisplayCount * displayPrice;
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
