namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string model = commands[0];
                int power = int.Parse(commands[1]);

                var engine = new Engine(model, power);

                if (commands.Length == 3)
                {
                    if (char.IsDigit(commands[2][0]))
                    {
                        string displacement = commands[2];
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = commands[2];
                        engine.Efficiency = efficiency;
                    }
                }
                else if (commands.Length == 4)
                {
                    string displacement = commands[2];
                    string efficiency = commands[3];

                    engine.Efficiency = efficiency;
                    engine.Displacement = displacement;
                }

                engines.Add(engine);
            }

            var cars = new List<Car>();
            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string model = commands[0];
                string engineModel = commands[1];

                var car = new Car(model, engineModel);

                if (commands.Length == 3)
                {
                    if (char.IsDigit(commands[2][0]))
                    {
                        string weight = commands[2];
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = commands[2];
                        car.Color = color;
                    }
                }
                else if (commands.Length == 4)
                {
                    string weight = commands[2];
                    string color = commands[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                foreach (var engine in engines.Where(x => x.Model == car.Engine))
                {
                    Console.WriteLine($"  {car.Engine}:");
                    Console.WriteLine($"    Power: {engine.Power}");
                    Console.WriteLine($"    Displacement: {engine.Displacement}");
                    Console.WriteLine($"    Efficiency: {engine.Efficiency}");
                }

                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}