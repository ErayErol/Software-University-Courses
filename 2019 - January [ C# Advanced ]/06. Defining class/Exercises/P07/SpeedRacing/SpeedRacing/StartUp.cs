namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var cars = new HashSet<Car>();
            var numberOfCars = int.Parse(Console.ReadLine());

            while (cars.Count < numberOfCars)
            {
                var carInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionForOneKm = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionForOneKm);
                cars.Add(car);
            }

            while (true)
            {
                var driveInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (driveInfo[0] == "End")
                {
                    Console.WriteLine(string.Join("\n", cars.Select(car => $"{car.Model} {car.FuelAmount:F2} {car.Distance}")));
                    break;
                }

                var currentCar = cars.Where(c => c.Model == driveInfo[1]).FirstOrDefault();

                if (currentCar != null)
                {
                    currentCar.Drive(double.Parse(driveInfo[2]));
                }
            }
        }
    }
}