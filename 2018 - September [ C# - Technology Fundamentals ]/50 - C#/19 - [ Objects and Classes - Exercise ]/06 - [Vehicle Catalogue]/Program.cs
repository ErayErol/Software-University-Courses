using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue2
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsList = new List<Car>();
            var trucksList = new List<Truck>();

            double carsTotalHP = 0.0;
            double carsCount = 0.0;

            double trucksTotalHP = 0.0;
            double trucksCount = 0.0;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var commands = input
                    .Split()
                    .ToList();

                string vehicleType = commands[0];
                string model = commands[1];
                string color = commands[2];
                int horsepower = int.Parse(commands[3]);

                if (vehicleType == "car")
                {
                    Car car = new Car(model, color, horsepower);

                    carsList.Add(car);

                    carsCount++;
                    carsTotalHP += car.Horsepower;
                }
                else
                {
                    Truck truck = new Truck(model, color, horsepower);

                    trucksList.Add(truck);

                    trucksCount++;
                    trucksTotalHP += truck.Horsepower;
                }
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                if (carsList.Select(x => x.Model).Contains(input))
                {
                    foreach (var vehicle1 in carsList)
                    {
                        if (vehicle1.Model == input)
                        {
                            Console.WriteLine($"Type: Car");
                            Console.WriteLine($"Model: {vehicle1.Model}");
                            Console.WriteLine($"Color: {vehicle1.Color}");
                            Console.WriteLine($"Horsepower: {vehicle1.Horsepower}");
                            break;
                        }
                    }
                }
                else if (trucksList.Select(x => x.Model).Contains(input))
                {
                    foreach (var vehicle1 in trucksList)
                    {
                        if (vehicle1.Model == input)
                        {
                            Console.WriteLine($"Type: Truck");
                            Console.WriteLine($"Model: {vehicle1.Model}");
                            Console.WriteLine($"Color: {vehicle1.Color}");
                            Console.WriteLine($"Horsepower: {vehicle1.Horsepower}");
                            break;
                        }
                    }
                }
            }

            if (carsList.Count == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {trucksTotalHP / trucksCount:f2}.");
            }
            if (trucksList.Count == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsTotalHP / carsCount:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");

            }

            if (carsList.Count >= 1 && trucksList.Count >= 1)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsTotalHP / carsCount:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {trucksTotalHP / trucksCount:f2}.");
            }
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public Car(string model, string color, int horsepower)
        {
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }
    }

    public class Truck
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public Truck(string model, string color, int horsepower)
        {
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }
    }
}
