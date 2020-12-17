namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            
            if (robot.IsChecked)
            {
                robot.Energy -= 8;
            }

            robot.Energy -= 8;
            robot.IsChecked = true;
        }
    }
}
