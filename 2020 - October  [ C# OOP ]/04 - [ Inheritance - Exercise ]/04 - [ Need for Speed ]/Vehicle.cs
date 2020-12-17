namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption
            => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            var canDrive = this.Fuel - kilometers * this.FuelConsumption >= 0;

            if (canDrive) 
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
        }
    }
}
