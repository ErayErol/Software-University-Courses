using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        /* •	Name – string
           •	Happiness – int (can't be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid happiness")
           •	Energy – int (can't be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid energy")
           •	ProcedureTime – int
           •	Owner – string (by default: "Service")
           •	IsBought – bool (by default: false)
           •	IsChipped – bool (by default: false)
           •	IsChecked – bool (by default: false)
            */

        private int energy;
        private int happiness;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = "Service";
            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }

        public int Happiness
        {
            get => happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidHappiness);
                }
                happiness = value;
            }
        }

        public int Energy
        {
            get => energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidEnergy);
                }
                energy = value;
            }
        }

        public string Name { get; }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
