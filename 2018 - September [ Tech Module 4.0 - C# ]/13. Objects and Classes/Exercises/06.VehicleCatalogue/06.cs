using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "End")
                {
                    break;
                }

                string type = commands[0];
                type = type.Replace(type.First(), char.ToUpper(type.First()));

                string model = commands[1];
                string colour = commands[2];
                int horsePower = int.Parse(commands[3]);

                Vehicle currentVehicle = new Vehicle(type, model, colour, horsePower);

                vehicles.Add(currentVehicle);
            }

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    break;
                }

                foreach (var vehicle in vehicles)
                {
                    if (vehicle.Model == model)
                    {
                        PrintVehicle(vehicle);
                        break;
                    }
                }
            }

            double carsSum = 0;
            double trucksSum = 0;

            foreach (var currentVehicle in vehicles)
            {
                if (currentVehicle.Type == "Car")
                {
                    carsSum += currentVehicle.HorsePower;
                }
                else
                {
                    trucksSum += currentVehicle.HorsePower;
                }
            }

            int countCar = vehicles.Where(x => x.Type == "Car").Count();
            int countCTruck = vehicles.Where(x => x.Type == "Truck").Count();

            if (countCar > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsSum / countCar:F2}.");
            }
            else if (countCar == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (countCTruck > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucksSum / countCTruck:F2}.");
            }
            else if (countCTruck == 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }

        private static void PrintVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"Type: {vehicle.Type}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Color: {vehicle.Colour}");
            Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
        }
    }

    class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }

        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string colour, int horsePower)
        {
            Type = type;
            Model = model;
            Colour = colour;
            HorsePower = horsePower;
        }
    }
}