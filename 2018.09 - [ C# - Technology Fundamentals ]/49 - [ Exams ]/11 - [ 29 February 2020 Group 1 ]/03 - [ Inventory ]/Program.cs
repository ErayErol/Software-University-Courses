using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventoryItems = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] commands = input.Split(new char[] { '-', ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string item = commands[1];
                switch (commands[0])
                {
                    case "Collect":
                        CollectingItem(inventoryItems, item);
                        break;
                    case "Drop":
                        DropingItem(inventoryItems, item);
                        break;
                    case "Combine":
                        item = commands[2];
                        string newItem = commands[3];

                        CombiningItem(inventoryItems, item, newItem);
                        break;
                    case "Renew":
                        RenewingItem(inventoryItems, item);
                        break;

                }
            }

            Console.WriteLine(string.Join(", ", inventoryItems));
        }

        static void CollectingItem(List<string> inventoryItems, string item)
        {
            if (!CheckingForItemExisting(inventoryItems, item))
            {
                inventoryItems.Add(item);
            }
        }

        static void DropingItem(List<string> inventoryItems, string item)
        {
            if (CheckingForItemExisting(inventoryItems, item))
            {
                inventoryItems.Remove(item);
            }
        }

        static void CombiningItem(List<string> inventoryItems, string item, string newItem)
        {
            if (CheckingForItemExisting(inventoryItems, item))
            {
                int index = inventoryItems.IndexOf(item);
                
                if (index == inventoryItems.Count - 1)
                {
                    inventoryItems.Add(newItem);
                }
                else
                {
                    inventoryItems.Insert(index+1, newItem);
                }
            }
        }

        static void RenewingItem(List<string> inventoryItems, string item)
        {
            if (CheckingForItemExisting(inventoryItems, item))
            {
                inventoryItems.Add(item);
                inventoryItems.Remove(item);
            }
        }

        static bool CheckingForItemExisting(List<string> inventoryItems, string item)
        {

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (item == inventoryItems[i])
                {
                    return true;
                }
            }

            return false;
        }

    }
}
