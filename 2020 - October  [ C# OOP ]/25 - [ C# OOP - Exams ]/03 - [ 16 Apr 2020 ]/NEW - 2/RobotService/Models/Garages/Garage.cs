using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Garages
{
    /* •	Capacity – int with a constant value of 10 
       •	Robots – Collection with the robot's name as the key and the robot itself as the value
        */
    public class Garage : IGarage
    {
        private const int CAPACITY = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots 
            => this.robots;

        /* If there isn't enough capacity in the garage throw an InvalidOperationException with the message "Not enough capacity"
           If a robot with this name already exists in the garage, throw an ArgumentException with the message "Robot {robot name} already exist"
           In any other case, add the current robot to the garage.
            */
        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == CAPACITY)
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.NotEnoughCapacity);
            }

            var robotName = robot.Name;
            if (this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} already exist");
            }

            this.robots.Add(robotName, robot);
        }

        /* If the provided robot name does not exist in the garage, throw an ArgumentException with the message "Robot {robot name} does not exist"
           If a robot with that name exists, change its owner, its bought status and remove the robot from the garage.
            */
        public void Sell(string robotName, string ownerName)
        {
            if (this.robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            var robot = this.robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
