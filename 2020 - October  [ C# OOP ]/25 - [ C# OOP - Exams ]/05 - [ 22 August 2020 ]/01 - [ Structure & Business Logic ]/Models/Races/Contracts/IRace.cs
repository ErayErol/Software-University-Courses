namespace EasterRaces.Models.Races.Contracts
{
    using EasterRaces.Models.Drivers.Contracts;

    using System.Collections.Generic;

    public interface IRace
    {
        string Name { get; }

        int Laps { get; }

        IReadOnlyCollection<IDriver> Drivers { get; }

        void AddDriver(IDriver driver);
    }
}