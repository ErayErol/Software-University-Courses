namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string model = commands[0];

                int engineSpeed = int.Parse(commands[1]);
                int enginePower = int.Parse(commands[2]);
                Engine engine = new Engine(enginePower, engineSpeed);

                int cargoWeight = int.Parse(commands[3]);
                string cargoType = commands[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(commands[5]);
                int tire1Age = int.Parse(commands[6]);
                double tire2Pressure = double.Parse(commands[7]);
                int tire2Age = int.Parse(commands[8]);
                double tire3Pressure = double.Parse(commands[9]);
                int tire3Age = int.Parse(commands[10]);
                double tire4Pressure = double.Parse(commands[11]);
                int tire4Age = int.Parse(commands[12]);

                var tires = new Tire[4]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age),
                };

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == type))
                {
                    bool pressure = car.Tires.Select(x => x.Pressure < 1).FirstOrDefault();
                    if (pressure)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (type == "flamable")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == type))
                {
                    bool pressure = car.Engine.Power > 250;
                    if (pressure)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}