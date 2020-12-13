using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal saving = decimal.Parse(Console.ReadLine());

            List<decimal> quality = Console.ReadLine().Split().Select(decimal.Parse).ToList();
            List<decimal> currentQuality = new List<decimal>(quality);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Hit it again, Gabsy!")
                {
                    Console.WriteLine(string.Join(" ", currentQuality));
                    Console.WriteLine($"Gabsy has {saving:F2}lv.");

                    break;
                }

                int hitPower = int.Parse(command);

                for (int i = 0; i < currentQuality.Count; i++)
                {
                    currentQuality[i] = currentQuality[i] - hitPower;

                    if (currentQuality[i] <= 0)
                    {
                        decimal currentPrice = quality[i] * 3;

                        if (currentPrice > saving)
                        {
                            currentQuality.RemoveAt(i);
                            quality.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            currentQuality[i] = quality[i];
                            saving = saving - currentPrice;
                        }
                    }
                }
            }
        }
    }
}