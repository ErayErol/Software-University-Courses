using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage _garage;
        private readonly Dictionary<Procedures, IProcedure> _procedures;

        public Controller()
        {
            this._garage = new Garage();
            this._procedures = new Dictionary<Procedures, IProcedure>()
            {
                {Procedures.Chip , new Chip()},
                {Procedures.TechCheck, new TechCheck()},
                {Procedures.Rest, new Rest()},
                {Procedures.Work, new Work()},
                {Procedures.Charge, new Charge()},
                {Procedures.Polish, new Polish()},
            };
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!Enum.TryParse(robotType, out RobotsTypes currRobotsType))
            {
                var msg = string.Format(ExceptionMessages.InvalidRobotType, robotType);
                throw new ArgumentException(msg);
            }

            IRobot robot = currRobotsType switch
            {
                RobotsTypes.PetRobot => new PetRobot(name, energy, happiness, procedureTime),
                RobotsTypes.HouseholdRobot => new HouseholdRobot(name, energy, happiness, procedureTime),
                RobotsTypes.WalkerRobot => new WalkerRobot(name, energy, happiness, procedureTime),
                _ => null
            };

            this._garage.Manufacture(robot);
            var outputMsg = string.Format(OutputMessages.RobotManufactured, name);
            return outputMsg;
        }

        public string Chip(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, Procedures.Chip, OutputMessages.ChipProcedure);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, Procedures.TechCheck, OutputMessages.TechCheckProcedure);
        }

        public string Rest(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, Procedures.Rest, OutputMessages.RestProcedure);
        }

        public string Work(string robotName, int procedureTime)
        {
            ExecuteProcedure(robotName, procedureTime, Procedures.Work, "");
            var msg = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return msg;
        }

        public string Charge(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, Procedures.Charge, OutputMessages.ChargeProcedure);
        }

        public string Polish(string robotName, int procedureTime)
        {
            return ExecuteProcedure(robotName, procedureTime, Procedures.Polish, OutputMessages.PolishProcedure);
        }

        public string Sell(string robotName, string ownerName)
        {
            var msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
            CheckRobotExisting(robotName, msg);

            var robot = this._garage.Robots[robotName];
            this._garage.Sell(robotName, ownerName);


            var outputMsg = robot.IsChipped
                ? $"{ownerName} bought robot with chip"
                : $"{ownerName} bought robot without chip";

            return outputMsg;
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out Procedures currProcedure);

            var procedure = this._procedures[currProcedure];

            return procedure.History().Trim();
        }

        private void CheckRobotExisting(string robotName, string msg)
        {
            if (!this._garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(msg);
            }
        }

        private string ExecuteProcedure(string robotName, int procedureTime, Procedures proc, string output)
        {
            var msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
            CheckRobotExisting(robotName, msg);

            var robot = this._garage.Robots[robotName];
            var procedure = this._procedures[proc];

            procedure.DoService(robot, procedureTime);

            var outputMsg = string.Format(output, robotName);
            return outputMsg;
        }
    }
}