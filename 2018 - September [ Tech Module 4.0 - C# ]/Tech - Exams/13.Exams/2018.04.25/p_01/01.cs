using System;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal lostGamesCount = decimal.Parse(Console.ReadLine());
            decimal priceHeadset = decimal.Parse(Console.ReadLine());
            decimal priceMouse = decimal.Parse(Console.ReadLine());
            decimal priceKeyboard = decimal.Parse(Console.ReadLine());
            decimal priceDispley= decimal.Parse(Console.ReadLine());
            
            decimal headset = 0;
            decimal mouse = 0;
            decimal keyboard = 0;
            decimal displey = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    headset++;
                }
                if (i % 3 == 0)
                {
                    mouse++;
                }
                if (i % 6 == 0)
                {
                    keyboard++;
                }
                if (i % 12 == 0)
                {
                    displey++;
                }
            }

            decimal expenses = (priceHeadset * headset) + (priceMouse * mouse) + (priceKeyboard * keyboard) + (priceDispley * displey);

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}