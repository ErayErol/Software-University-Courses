namespace RobotService.Models.Procedures
{
    using Contracts;
    using RobotService.Models.Robots.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        private ICollection<IRobot> robots;

        protected Procedure()
        {
            this.robots = new Collection<IRobot>();
        }

        public virtual string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            foreach (IRobot robot in this.robots)
            {
                sb.AppendLine(
                    $" Robot type: {robot.GetType().Name} - {robot.Name} - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }

            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }
    }
}
