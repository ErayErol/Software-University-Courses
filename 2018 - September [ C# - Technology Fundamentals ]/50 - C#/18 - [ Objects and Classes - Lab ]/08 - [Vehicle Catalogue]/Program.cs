using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var carsCatalog = new List<Car>();
            var trucksCatalog = new List<Truck>();

            while ((input = Console.ReadLine()) != "end")
            {
                var splittedInput = input
                    .Split("/")
                    .ToList();

                string type = splittedInput[0];
                string brand = splittedInput[1];
                string model = splittedInput[2];
                int vehicleArg = int.Parse(splittedInput[3]);

                if (type == "Truck")
                {
                    Truck truck = new Truck();

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = vehicleArg;

                    trucksCatalog.Add(truck);
                }
                else
                {
                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = vehicleArg;

                    carsCatalog.Add(car);
                }
            }

            if (carsCatalog.Count >= 1)
            {
                Console.WriteLine("Cars:");
                foreach (Car car1 in carsCatalog.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car1.Brand}: {car1.Model} - {car1.HorsePower}hp");
                }
            }

            if (trucksCatalog.Count >= 1)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck trucks1 in trucksCatalog.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{trucks1.Brand}: {trucks1.Model} - {trucks1.Weight}kg");
                }
            }
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
}
