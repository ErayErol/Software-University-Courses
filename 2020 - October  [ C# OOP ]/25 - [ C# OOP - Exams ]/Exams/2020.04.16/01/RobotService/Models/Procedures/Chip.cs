namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;
    using System;

    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.IsChipped)
            {
                throw new ArgumentException($"{robot.Name} is already chipped");
            }

            base.DoService(robot, procedureTime);
            robot.Happiness -= 5;
            robot.IsChipped = true;
        }
    }
}
