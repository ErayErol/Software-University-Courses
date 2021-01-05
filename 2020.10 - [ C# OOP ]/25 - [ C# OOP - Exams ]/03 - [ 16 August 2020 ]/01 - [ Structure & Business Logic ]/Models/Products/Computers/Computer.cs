namespace OnlineShop.Models.Products.Computers
{
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Computer : Product, IComputer
    {
        private const string ONE_WHITE_SPACE = " ";
        private const string TWO_WHITE_SPACE = "  ";

        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components 
            => components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals 
            => peripherals.ToList().AsReadOnly();

        public override double OverallPerformance
            => this.components.Count == 0
                ? base.OverallPerformance
                : base.OverallPerformance + this.components.Average(x => x.OverallPerformance); // TODO: Maybe check this

        public override decimal Price
        {
            get
            {
                var computerTotalPrice = base.Price; // TODO: Check is this computer total sum of the computer price
                var totalPriceOfComponents = this.components.Sum(x => x.Price);
                var totalPriceOfPeri = this.peripherals.Sum(x => x.Price);

                var totalSum = computerTotalPrice + totalPriceOfComponents + totalPriceOfPeri;
                return totalSum;
            }
        }

        public void AddComponent(IComponent component)
        {
            if (this.components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name) != null)
            {
                var msg = string.Format(Common.Constants.ExceptionMessages.ExistingComponent, component.GetType().Name,
                    this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (this.components.Count == 0 || component == null)
            {
                var msg = string.Format(Common.Constants.ExceptionMessages.NotExistingComponent, componentType,
                    this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Remove(component);
            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name) != null)
            {
                var msg = string.Format(Common.Constants.ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name,
                    this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (this.peripherals.Count == 0 || peripheral == null)
            {
                var msg = string.Format(Common.Constants.ExceptionMessages.NotExistingPeripheral, peripheralType,
                    this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            var formatMsg = string.Format(Common.Constants.SuccessMessages.ComputerComponentsToString, this.components.Count);
            var resultFromFormatMsg = $"{ONE_WHITE_SPACE}{formatMsg}";
            sb.AppendLine(resultFromFormatMsg);

            if (this.components.Count > 0)
            {
                foreach (var component in this.components)
                {
                    sb.AppendLine($"{TWO_WHITE_SPACE}{component}");
                }
            }

            var average = 0.00;
            formatMsg = string.Format(Common.Constants.SuccessMessages.ComputerPeripheralsToString, this.peripherals.Count, $"{average:F2}");
            resultFromFormatMsg = $"{ONE_WHITE_SPACE}{formatMsg}";
            string endMsg;

            if (this.peripherals.Count == 0)
            {
                sb.AppendLine(resultFromFormatMsg);
                endMsg = sb.ToString().TrimEnd();
                return endMsg;
            }

            average = this.peripherals.Average(x => x.OverallPerformance);
            formatMsg = string.Format(Common.Constants.SuccessMessages.ComputerPeripheralsToString, this.peripherals.Count, $"{average:F2}");
            resultFromFormatMsg = $"{ONE_WHITE_SPACE}{formatMsg}";
            sb.AppendLine(resultFromFormatMsg);

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"{TWO_WHITE_SPACE}{peripheral}");
            }

            endMsg = sb.ToString().TrimEnd();
            return endMsg;
        }
    }
}