namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Charge : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness += 12;
            robot.Energy += 10;
        }
    }
}