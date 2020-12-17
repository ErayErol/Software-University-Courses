using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private readonly ICollection<IRobot> robots;

        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        /* Returns a string with information about current procedure and its robots. The returned string must be in the following format:
           "{procedure type}"
           " Robot type: {robot type} - {robot name} - Happiness: {happiness} - Energy: {energy}"
           Note: You should append robot information for each robot in the collection!
            */

        // TODO: Check this
        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (var robot in this.robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        /* Each procedure implements its own DoService() method with different logic, which is explained below.
           Each procedure must check if the robot procedure time is more than or equal to the time each procedure will take. If robot procedure time is lower than the time for the current procedure throw ArgumentException with message "Robot doesn't have enough procedure time"
           Every time a procedure command is called, the time the procedure took is subtracted from the robot’s allowed procedure time.
            */

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }

        /* •	Chip – removes 5 happiness and chips current robot. Robot can be chipped once. If robot is already chipped throw an ArgumentException with message "{robot name} is already chipped"
           •	Charge – adds 12 happiness and 10 energy
           •	Rest – removes 3 happiness and adds 10 energy
           •	Polish – removes 7 happiness
           •	Work – removes 6 energy and adds 12 happiness
           •	TechCheck – removes 8 energy and checks current robot (set IsChecked to true). If robot is already checked, just remove 8 energy again.
            */
    }
}
