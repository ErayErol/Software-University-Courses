namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Vehicles.Factories;
    using Vehicles.IO;
    using Vehicles.Models;
    using Vehicles.Utilities.Enums;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Proceed()
        {
            VehicleType type;
            double fuelQuantity;
            double fuelConsumption;

            var carData = Reading(this.reader);
            GetArgs(carData, out type, out fuelQuantity, out fuelConsumption);
            IVehicle car = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption);

            var truckData = Reading(this.reader);
            GetArgs(truckData, out type, out fuelQuantity, out fuelConsumption);
            IVehicle truck = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption);

            var commandsCount = int.Parse(reader.ReadLine());
            DoCommand(commandsCount, car, truck);

            Print(car, truck);
        }

        private void DoCommand(int commandsCount, IVehicle car, IVehicle truck)
        {
            for (int i = 1; i <= commandsCount; i++)
            {
                var input = Reading(this.reader);

                var command = input[0];
                Enum.TryParse(input[1], out VehicleType vehicleType);
                var argument = double.Parse(input[2]);

                var vehicle = GetVehicle(car, truck, vehicleType);

                if (command == "Drive")
                {
                    DriveVehicle(vehicle, argument);
                }
                else if (command == "Refuel")
                {
                    RefuelVehicle(vehicle, argument);
                }
            }
        }

        private static IVehicle GetVehicle(IVehicle car, IVehicle truck, VehicleType vehicleType)
        {
            IVehicle vehicle = vehicleType switch
            {
                VehicleType.Car => car,
                VehicleType.Truck => truck,
                _ => null
            };
            return vehicle;
        }

        private static void GetArgs(List<string> carData, out VehicleType type, out double fuelQuantity, out double fuelConsumption)
        {
            Enum.TryParse(carData[0], out type);
            fuelQuantity = double.Parse(carData[1]);
            fuelConsumption = double.Parse(carData[2]);
        }

        private void DriveVehicle(IVehicle vehicle, double distance)
        {
            bool isDrive = vehicle.Drive(distance);
            string vehicleType = vehicle.GetType().Name;

            this.writer.WriteLine(isDrive
                    ? $"{vehicleType} travelled {distance} km"
                    : $"{vehicleType} needs refueling");
        }

        private static void RefuelVehicle(IVehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }

        private void Print(IVehicle car, IVehicle truck)
        {
            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
        }

        private static List<string> Reading(IReader reader)
            => reader
                .ReadLine()
                .Split()
                .ToList();
    }
}
