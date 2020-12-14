namespace RobotService.Models.Garages
{
    using Contracts;
    using RobotService.Models.Robots.Contracts;
    using System;
    using System.Collections.Generic;

    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots
            => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            var name = robot.Name;
            if (this.robots.ContainsKey(name))
            {
                throw new ArgumentException($"Robot {name} already exist");
            }

            this.robots[name] = robot;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (this.robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
