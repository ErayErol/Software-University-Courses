using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            var parking = new HashSet<string>();

            while (true)
            {
                var commands = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "END")
                {
                    if (parking.Count == 0)
                    {
                        Console.WriteLine("Parking Lot is Empty");
                        return;
                    }
                    Console.WriteLine(string.Join("\r\n", parking));
                    break;
                }

                string direction = commands[0];
                string carNumber = commands[1];

                parking.Add(carNumber);

                if (direction == "OUT")
                {
                    parking.Remove(carNumber);
                }
            }
        }
    }
}