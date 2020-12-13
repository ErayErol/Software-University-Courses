namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionForOneKm;
        private double distance;

        public Car(string model, double fuelAmount, double fuelConsumptionForOneKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionForOneKm = fuelConsumptionForOneKm;
            this.Distance = 0;
        }

        public double Distance
        {
            get { return this.distance; }
            set { this.distance = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionForOneKm
        {
            get { return this.fuelConsumptionForOneKm; }
            set { this.fuelConsumptionForOneKm = value; }
        }

        public void Drive(double kilometers)
        {
            var neededFuel = kilometers * this.fuelConsumptionForOneKm;

            if (this.fuelAmount < neededFuel)
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            this.fuelAmount -= neededFuel;
            this.distance += kilometers;
        }
    }
}