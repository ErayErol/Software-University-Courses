namespace EasterRaces.Core.Entities
{
    using EasterRaces.Core.Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Utilities.Enums;
    using System;
    using System.Linq;
    using System.Text;

    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_DRIVER_RACER = 3;

        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            var driverExist = this.driverRepository.GetByName(driverName);
            string msg = string.Format(Utilities.Messages.OutputMessages.DriverCreated, driverName);

            if (driverExist != null)
            {
                msg = string.Format(Utilities.Messages.ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(msg);
            }

            var driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return msg;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            Enum.TryParse(type, out CarType carType);

            ICar car = carType switch
            {
                CarType.Muscle => new MuscleCar(model, horsePower),
                CarType.Sports => new SportsCar(model, horsePower),
                _ => null,
            };

            var msg = string.Empty;
            if (car == null)
            {
                return msg;
            }

            msg = string.Format(Utilities.Messages.ExceptionMessages.CarExists, model);

            var carExist = this.carRepository.GetByName(model);
            if (carExist != null)
            {
                throw new ArgumentException(msg);
            }

            this.carRepository.Add(car);
            msg = string.Format(Utilities.Messages.OutputMessages.CarCreated, car.GetType().Name, model);
            return msg;
        }

        public string CreateRace(string name, int laps)
        {
            var isRaceExist = this.raceRepository.GetByName(name);

            var msg = string.Format(Utilities.Messages.OutputMessages.RaceCreated, name);
            if (isRaceExist != null)
            {
                msg = string.Format(Utilities.Messages.ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(msg);
            }

            var race = new Race(name, laps);
            this.raceRepository.Add(race);
            return msg;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var msg = string.Format(Utilities.Messages.ExceptionMessages.RaceNotFound, raceName);
            
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(msg);
            }

            var driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                msg = string.Format(Utilities.Messages.ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(msg);
            }

            race.AddDriver(driver);
            this.driverRepository.Remove(driver); // TODO: Should I do this??

            msg = string.Format(Utilities.Messages.OutputMessages.DriverAdded, driverName, raceName);
            return msg;
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var msg = string.Format(Utilities.Messages.ExceptionMessages.DriverNotFound, driverName);

            var driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(msg);
            }

            var car = this.carRepository.GetByName(carModel);
            if (car == null)
            {
                msg = string.Format(Utilities.Messages.ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(msg);
            }

            driver.AddCar(car);
            this.carRepository.Remove(car); // TODO: Should I do this??

            msg = string.Format(Utilities.Messages.OutputMessages.CarAdded, driverName, carModel);
            return msg;
        }

        public string StartRace(string raceName)
        {
            var msg = string.Format(Utilities.Messages.ExceptionMessages.RaceNotFound, raceName);

            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(msg);
            }

            var racersCanDrive = race.Drivers.Count(raceDriver => raceDriver.CanParticipate);
            if (racersCanDrive < MIN_DRIVER_RACER)
            {
                msg = string.Format(Utilities.Messages.ExceptionMessages.RaceInvalid, raceName, MIN_DRIVER_RACER);
                throw new InvalidOperationException(msg);
            }

            this.raceRepository.Remove(race);
            var drivers = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var winner = drivers[0];
            var second = drivers[1];
            var third = drivers[2];
            winner.WinRace();;

            var sb = new StringBuilder();
            
            sb.AppendLine(string.Format(Utilities.Messages.OutputMessages.DriverFirstPosition, winner.Name, raceName));
            sb.AppendLine(string.Format(Utilities.Messages.OutputMessages.DriverSecondPosition, second.Name, raceName));
            sb.AppendLine(string.Format(Utilities.Messages.OutputMessages.DriverThirdPosition, third.Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
