using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> giftsList = Console
                .ReadLine()
                .Split()
                .ToList();

            string input;

            string giftName = string.Empty;
            int index = 0;

            while ((input = Console.ReadLine()) != "No Money")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "OutOfStock":
                        giftName = commands[1];

                        ChangingItemToOutOfStock(giftsList, giftName);
                        break;
                    case "Required":
                        giftName = commands[1];
                        index = int.Parse(commands[2]);

                        ReplacingOldGiftWithNewOne(giftsList, giftName, index);
                        break;
                    case "JustInCase":
                        giftName = commands[1];

                        ReplacingLastGiftWithNewOne(giftsList, giftName);
                        break;
                }
            }

            for (int i = 0; i < giftsList.Count; i++)
            {
                if (giftsList[i] != "None")
                {
                    Console.Write(giftsList[i] + " ");
                }
            }
        }

        static void ChangingItemToOutOfStock(List<string> giftsList, string giftName)
        {
            for (int i = 0; i < giftsList.Count; i++)
            {
                if (giftsList.Contains(giftName))
                {
                    int index = giftsList.IndexOf(giftName);
                    giftsList[index] = "None";
                }
            }
        }

        static void ReplacingOldGiftWithNewOne(List<string> giftsList, string giftName, int index)
        {
            if (index >= 0 && index < giftsList.Count)
            {
                giftsList[index] = giftName;
            }
        }

        static void ReplacingLastGiftWithNewOne(List<string> giftsList, string giftName)
        {
            giftsList[giftsList.Count - 1] = giftName;
        }
    }
}
