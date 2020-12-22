namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;
    using System;

    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                var msg = string.Format(ExceptionMessages.AlreadyChipped, robot.Name);

                throw new ArgumentException(msg);
            }

            robot.Happiness -= 5;
            robot.IsChipped = true;
        }
    }
}