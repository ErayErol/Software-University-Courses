using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console
                .ReadLine()
                .Split()
                .ToList();

            int commandsCount = int.Parse(Console.ReadLine());

            string shopName = string.Empty;

            for (int i = 1; i <= commandsCount; i++)
            {
                string[] commands = Console
                    .ReadLine()
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Include":
                        shopName = commands[1];

                        AddingShopToTheList(shops, shopName);
                        break;
                    case "Visit":
                        int shopsCount = int.Parse(commands[2]);

                        switch (commands[1])
                        {
                            case "first":
                                RemovingFirstCountOfShops(shops, shopsCount);
                                break;
                            case "last":
                                RemovingLastCountOfShops(shops, shopsCount);
                                break;
                        }
                        break;
                    case "Prefer":
                        int firstIndex = int.Parse(commands[1]);
                        int secondIndex = int.Parse(commands[2]);

                        ChangingShopsPositions(shops, firstIndex, secondIndex);
                        break;
                    case "Place":
                        shopName = commands[1];
                        int shopIndex = int.Parse(commands[2]);

                        InsertingShop(shops, shopName, shopIndex);
                        break;
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }

        static void AddingShopToTheList(List<string> shops, string shopName)
        {
            shops.Add(shopName);
        }

        static void RemovingFirstCountOfShops(List<string> shops, int shopsCount)
        {
            if (shopsCount <= shops.Count)
            {
                shops.RemoveRange(0, shopsCount);
            }
        }

        static void RemovingLastCountOfShops(List<string> shops, int shopsCount)
        {
            if (shopsCount <= shops.Count)
            {
                shops.RemoveRange(shops.Count - shopsCount, shopsCount);
            }
        }

        static void ChangingShopsPositions(List<string> shops, int firstIndex, int secondIndex)
        {
            if ((firstIndex >= 0 && firstIndex < shops.Count) &&
                (secondIndex >= 0 && secondIndex < shops.Count))
            {
                string firstTemp = shops[firstIndex];
                string secondTemp = shops[secondIndex];

                shops[firstIndex] = secondTemp;
                shops[secondIndex] = firstTemp;
            }
        }

        static void InsertingShop(List<string> shops, string shopName, int shopIndex)
        {
            if (shopIndex >= 0 && shopIndex < shops.Count)
            {
                shops.Insert(shopIndex+1, shopName);
            }
        }
    }
}
