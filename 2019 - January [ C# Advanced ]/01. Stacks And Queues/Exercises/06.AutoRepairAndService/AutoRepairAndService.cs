using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.AutoRepairAndService
{
    class AutoRepairAndService
    {
        static void Main(string[] args)
        {
            string[] cars = Console.ReadLine().Split();
            var carList = new Queue<string>(cars);
            var serverdCars = new Stack<string>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split('-');

                if (commands[0] == "Service")
                {
                    if (carList.Count > 0)
                    {
                        serverdCars.Push(carList.Peek());
                        Console.WriteLine($"Vehicle {carList.Dequeue()} got served.");
                    }
                }
                else if (commands[0] == "CarInfo")
                {
                    var currentCar = commands[1];
                    if (cars.Contains(currentCar))
                    {
                        if (carList.Contains(currentCar))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }
                    }
                }
                else if (commands[0] == "History")
                {
                    Console.WriteLine($"{string.Join(", ", serverdCars)}");
                }
                else if (commands[0] == "End")
                {
                    if (carList.Count > 0)
                    {
                        Console.WriteLine($"Vehicles for service: {string.Join(", ", carList)}");
                    }

                    Console.WriteLine($"Served vehicles: {string.Join(", ", serverdCars)}");
                    return;
                }
            }
        }
    }
}