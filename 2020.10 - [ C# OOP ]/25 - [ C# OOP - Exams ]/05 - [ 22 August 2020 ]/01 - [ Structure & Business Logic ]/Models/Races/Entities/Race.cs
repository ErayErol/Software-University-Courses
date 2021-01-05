namespace EasterRaces.Models.Races.Entities
{
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Race : IRace
    {
        private const int MIN_LAPS = 1;
        private const int MIN_NAME_SYMBOLS = 5;

        private string name;
        private int laps;

        private readonly ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.drivers = new List<IDriver>();
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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < MIN_LAPS)
                {
                    string msg = string.Format(Utilities.Messages.ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS);
                    throw new ArgumentException(msg);
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
            => this.drivers.ToList().AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            string msg = string.Format(Utilities.Messages.ExceptionMessages.DriverInvalid);
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(IDriver), msg);
            }

            if (driver.CanParticipate == false)
            {
                msg = string.Format(Utilities.Messages.ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(msg);
            }

            if (this.drivers.Any(x => x.Name == driver.Name))
            {
                msg = string.Format(Utilities.Messages.ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name);
                throw new ArgumentNullException(nameof(IDriver), msg);
            }

            this.drivers.Add(driver);
        }
    }
}
