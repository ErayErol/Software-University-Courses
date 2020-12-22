namespace EasterRaces.Models.Drivers.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using System;

    public class Driver : IDriver
    {
        private const int MIN_NAME_SYMBOLS = 5;
        
        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    string msg = string.Format(Utilities.Messages.ExceptionMessages.InvalidName, value, MIN_NAME_SYMBOLS);
                    throw new ArgumentException(msg);
                }
                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
            => this.Car != null;

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(ICar), Utilities.Messages.ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }
    }
}
