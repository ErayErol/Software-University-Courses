using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vehicles.Models;
using Vehicles.Utilities.Enums;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(VehicleType type, double fuelQuantity, double fuelConsumption, bool hasAirConditioner = true)
        {
            IVehicle vehicle = type switch
            {
                VehicleType.Car => new Car(fuelQuantity, fuelConsumption, hasAirConditioner),
                VehicleType.Truck => new Truck(fuelQuantity, fuelConsumption, hasAirConditioner),
                _ => null
            };

            return vehicle;
        }
    }
}
