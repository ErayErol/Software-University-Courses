using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var productsList = new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                var splittedInput = input
                    .Split()
                    .ToList();

                string serialNumber = splittedInput[0];
                string itemName = splittedInput[1];
                int itemQty = int.Parse(splittedInput[2]);
                double itemPrice = double.Parse(splittedInput[3]);

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.Item = itemName;
                box.ItemQty = itemQty;
                box.ItemPrice = itemPrice;
                box.BoxPrice = itemPrice * itemQty;

                productsList.Add(box);
            }

            foreach (Box box in productsList.OrderByDescending(x => x.BoxPrice))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item} - ${box.ItemPrice:f2}: {box.ItemQty}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }
    }

    public class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQty { get; set; }
        public double ItemPrice { get; set; }
        public double BoxPrice { get; set; }
    }
}
