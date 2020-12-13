using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "end")
                {
                    break;
                }

                string boxSerialNumber = commands[0];
                string boxItemName = commands[1];
                int boxItemQuantity = int.Parse(commands[2]);
                decimal boxItemPrice = decimal.Parse(commands[3]);

                Box currentBox = new Box(boxSerialNumber, boxItemName, boxItemQuantity, boxItemPrice);

                boxes.Add(currentBox);
            }

            foreach (Box box in boxes.OrderByDescending(x => x.PriceForABox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:F2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Box
    {
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal PriceForABox { get; set; }

        public Box(string boxSerialNumber, string boxItemName, int boxItemQuantity, decimal boxItemPrice)
        {
            this.Item = new Item();

            this.SerialNumber = boxSerialNumber;
            this.Item.Name = boxItemName;
            this.ItemQuantity = boxItemQuantity;
            this.Item.Price = boxItemPrice;
            this.PriceForABox = boxItemPrice * boxItemQuantity;
        }
    }
}