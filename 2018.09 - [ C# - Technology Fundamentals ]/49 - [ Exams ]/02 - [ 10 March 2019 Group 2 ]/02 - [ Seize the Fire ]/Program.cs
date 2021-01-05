using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            var cellsList = Console
                .ReadLine()
                .Split("#")
                .ToList();

            int water = int.Parse(Console.ReadLine());

            double effort = 0;
            double totalFire = 0;

            var cells = new List<int>();

            for (int i = 0; i < cellsList.Count; i++)
            {
                string[] command = cellsList[i].Split(" = ");

                string cellType = command[0];
                int cell = int.Parse(command[1]);

                if (((cellType == "High") && (cell >= 81) && (cell <= 125) && (water >= cell)) ||
                    ((cellType == "Medium") && (cell >= 51) && (cell <= 80) && (water >= cell)) ||
                    ((cellType == "Low") && (cell >= 1) && (cell <= 50) && (water >= cell)))
                {
                    cells.Add(cell);
                    effort += cell * 0.25;
                    totalFire += cell;
                    water -= cell;
                }
            }

            Console.WriteLine("Cells:");

            foreach (var item in cells)
            {
                Console.WriteLine($"- {item}");
            }

            Console.WriteLine($"Effort: {effort:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
