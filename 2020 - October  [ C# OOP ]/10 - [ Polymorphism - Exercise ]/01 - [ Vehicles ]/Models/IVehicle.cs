namespace Vehicles.Models
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        bool HasAirConditioner { get; }

        bool Drive(double distance);

        void Refuel(double amount);
    }
}
