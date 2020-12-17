namespace Cars
{
    using Cars;

    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} with {this.Battery} Batteries";
        }
    }
}