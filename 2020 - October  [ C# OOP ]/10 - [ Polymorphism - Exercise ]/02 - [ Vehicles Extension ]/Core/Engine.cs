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
            Vehicle(out var car, out var truck, out var bus);

            var commandsCount = int.Parse(reader.ReadLine());
            DoCommands(commandsCount, car, truck, bus);

            List<IVehicle> vehicles = new List<IVehicle>() { car, truck, bus, };
            Print(vehicles);
        }

        private void Vehicle(out IVehicle car, out IVehicle truck, out IVehicle bus)
        {
            VehicleType type;
            double fuelQuantity;
            double fuelConsumption;
            double tankCapacity;

            var carData = Reading(this.reader);
            GetArgs(carData, out type, out fuelQuantity, out fuelConsumption, out tankCapacity);
            car = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

            var truckData = Reading(this.reader);
            GetArgs(truckData, out type, out fuelQuantity, out fuelConsumption, out tankCapacity);
            truck = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

            var busData = Reading(this.reader);
            GetArgs(busData, out type, out fuelQuantity, out fuelConsumption, out tankCapacity);
            bus = this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);
        }

        private void DoCommands(int commandsCount, IVehicle car, IVehicle truck, IVehicle bus)
        {
            for (int i = 1; i <= commandsCount; i++)
            {
                var input = Reading(this.reader);

                var command = input[0];
                Enum.TryParse(input[1], out VehicleType vehicleType);
                var argument = double.Parse(input[2]);

                var vehicle = GetVehicle(car, truck, bus, vehicleType);

                try
                {
                    ExecuteCommand(command, vehicle, argument);
                }
                catch (Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }

        private void ExecuteCommand(string command, IVehicle vehicle, double argument)
        {
            if (command == "Drive")
            {
                DriveVehicle(vehicle, argument);
            }
            else if (command == "DriveEmpty")
            {
                DriveEmptyVehicle(vehicle, argument);
            }
            else if (command == "Refuel")
            {
                RefuelVehicle(vehicle, argument);
            }
        }

        private static IVehicle GetVehicle(IVehicle car, IVehicle truck, IVehicle bus, VehicleType vehicleType)
        {
            IVehicle vehicle = vehicleType switch
            {
                VehicleType.Car => car,
                VehicleType.Truck => truck,
                VehicleType.Bus => bus,
                _ => null
            };
            return vehicle;
        }

        private static void GetArgs(List<string> data, out VehicleType type, out double fuelQuantity, out double fuelConsumption, out double tankCapacity)
        {
            Enum.TryParse(data[0], out type);
            fuelQuantity = double.Parse(data[1]);
            fuelConsumption = double.Parse(data[2]);
            tankCapacity = double.Parse(data[3]);
        }

        private void DriveVehicle(IVehicle vehicle, double distance)
        {
            bool isDrive = vehicle.Drive(distance);
            string vehicleType = vehicle.GetType().Name;

            PrintDrive(distance, isDrive, vehicleType);
        }

        private void DriveEmptyVehicle(IVehicle vehicle, double distance)
        {
            Bus bus = (Bus)vehicle;
            bool isDrive = bus.DriveEmpty(distance);
            string vehicleType = vehicle.GetType().Name;

            PrintDrive(distance, isDrive, vehicleType);
        }

        private void PrintDrive(double distance, bool isDrive, string vehicleType)
        {
            this.writer.WriteLine(isDrive
                ? $"{vehicleType} travelled {distance} km"
                : $"{vehicleType} needs refueling");
        }

        private static void RefuelVehicle(IVehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }

        private void Print(List<IVehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                this.writer.WriteLine(vehicle.ToString());
            }
        }

        private static List<string> Reading(IReader reader)
            => reader
                .ReadLine()
                .Split()
                .ToList();
    }
}
