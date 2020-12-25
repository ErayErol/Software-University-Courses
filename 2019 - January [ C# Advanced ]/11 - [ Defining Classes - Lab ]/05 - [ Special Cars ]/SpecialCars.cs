namespace _05.SpecialCars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpecialCars
    {
        static void Main()
        {
            var tires = Tires();

            var engines = Engines();

            var cars = new List<Car>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Show special")
                {
                    ShowSpecial(cars);
                }

                var currentModel = command.Split();

                string make = currentModel[0];
                string model = currentModel[1];
                int year = int.Parse(currentModel[2]);

                double fuelQuantity = double.Parse(currentModel[3]);
                double fuelConsumption = double.Parse(currentModel[4]);

                int engineIndex = int.Parse(currentModel[5]);

                int tiresIndex = int.Parse(currentModel[6]);

                var car =
                    new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }
        }

        private static void ShowSpecial(List<Car> cars)
        {
            foreach (var car in cars)
            {
                bool enoughFuel = Car.Drive(20, car);

                double pressureSum = 0.0;

                for (int i = 0; i < car.Tires.Length; i++)
                {
                    pressureSum += car.Tires[i].Pressure;
                }

                if (enoughFuel &&
                    car.Year >= 2017 &&
                    car.Engine.HorsePower > 330 &&
                    pressureSum > 9 &&
                    pressureSum < 10)
                {
                    car.FuelQuantity -= (20 * car.FuelConsumption / 100);
                    Console.WriteLine(Car.WhoAmI(car));
                }
            }
        }

        private static List<Engine> Engines()
        {
            var engines = new List<Engine>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                var currentEngine = command.Split().Select(double.Parse).ToArray();

                var engine = new Engine((int)currentEngine[0], currentEngine[1]);

                engines.Add(engine);
            }

            return engines;
        }

        private static List<Tire[]> Tires()
        {
            var tires = new List<Tire[]>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }

                var currentTires = command.Split().Select(double.Parse).ToArray();

                var tiresPack = new Tire[4];
                int numberOfTires = 0;

                for (int i = 0; i < currentTires.Length - 1; i += 2)
                {
                    var currentTire = new Tire((int)currentTires[i], currentTires[i + 1]);
                    tiresPack[numberOfTires++] = currentTire;
                }

                tires.Add(tiresPack);
            }

            return tires;
        }
    }

    public class Car
    {
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
            Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public static bool Drive(double distance, Car car)
        {
            return car.FuelQuantity - (distance * car.FuelConsumption / 100) > 0 ? true : false;
        }

        public static string WhoAmI(Car car)
        {
            StringBuilder carInfo = new StringBuilder();
            carInfo.AppendLine($"Make: {car.Make}");
            carInfo.AppendLine($"Model: {car.Model}");
            carInfo.AppendLine($"Year: {car.Year}");
            carInfo.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
            carInfo.Append($"FuelQuantity: {car.FuelQuantity}");
            return carInfo.ToString();
        }
    }

    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }
    }

    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get; set; }

        public double Pressure { get; set; }
    }
}