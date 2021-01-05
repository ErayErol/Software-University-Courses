using Vehicles.Models;
using Vehicles.Utilities.Enums;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(VehicleType type, double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true)
        {
            IVehicle vehicle = type switch
            {
                VehicleType.Car => new Car(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner),
                VehicleType.Truck => new Truck(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner),
                VehicleType.Bus => new Bus(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner),
                _ => null
            };

            return vehicle;
        }
}
}
