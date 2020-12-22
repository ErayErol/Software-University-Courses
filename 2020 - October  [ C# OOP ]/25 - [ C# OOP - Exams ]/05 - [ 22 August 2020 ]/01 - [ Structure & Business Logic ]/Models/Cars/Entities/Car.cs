namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using System;

    public abstract class Car : ICar
    {
        private const int MIN_MODEL_SYMBOLS = 4;
        
        private int minHorsePower;
        private int maxHorsePower;

        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    string msg = string.Format(Utilities.Messages.ExceptionMessages.InvalidModel, value, MIN_MODEL_SYMBOLS);
                    throw new ArgumentException(msg);
                }
                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    string msg = string.Format(Utilities.Messages.ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(msg);
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
