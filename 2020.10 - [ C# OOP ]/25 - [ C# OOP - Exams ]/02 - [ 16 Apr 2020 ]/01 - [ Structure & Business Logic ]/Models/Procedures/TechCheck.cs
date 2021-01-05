namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= 6;
            robot.IsChecked = true;
        }
    }
}