namespace RobotService.Models.Garages.Contracts
{
    using RobotService.Models.Robots.Contracts;
    using System.Collections.Generic;

    public interface IGarage
    {
        IReadOnlyDictionary<string, IRobot> Robots { get; }

        void Manufacture(IRobot robot);

        void Sell(string robotName, string ownerName);
    }
}
