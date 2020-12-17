using Vehicles.Models;
using Vehicles.Utilities.Enums;

namespace Vehicles.Factories
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(VehicleType type, double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true);
    }
}
