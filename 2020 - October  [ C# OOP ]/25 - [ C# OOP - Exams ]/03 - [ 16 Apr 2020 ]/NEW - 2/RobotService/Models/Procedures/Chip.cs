using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            // TODO: Check this
            if (robot.IsChipped)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.AlreadyChipped);
            }

            base.DoService(robot, procedureTime);
            
            robot.Happiness -= 5;
            robot.IsChipped = true;
        }
    }
}
