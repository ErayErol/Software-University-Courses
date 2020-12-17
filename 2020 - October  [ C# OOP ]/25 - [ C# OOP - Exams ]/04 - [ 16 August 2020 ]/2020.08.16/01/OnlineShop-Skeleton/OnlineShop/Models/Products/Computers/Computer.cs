namespace OnlineShop.Models.Products.Computers
{
    using Components;
    using Peripherals;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> _components;
        private readonly List<IPeripheral> _peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this._components = new List<IComponent>();
            this._peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
            => CalculateOverallPerformance();

        public override decimal Price
            => CalculatePrice();

        public IReadOnlyCollection<IComponent> Components
            => _components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => _peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this._components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this._components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this._components.Remove(component);
            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this._peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this._peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this._peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this._peripherals.Remove(peripheral);
            return peripheral;
        }

        private double CalculateOverallPerformance()
        {
            if (this._components.Count == 0)
            {
                return base.OverallPerformance;
            }

            var averageOverallPerformance = this._components.Average(x => x.OverallPerformance);
            return base.OverallPerformance + averageOverallPerformance;
        }

        private decimal CalculatePrice()
        {
            return base.Price
                   + this._components.Sum(x => x.Price)
                   + this._peripherals.Sum(x => x.Price);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($" Components ({this._components.Count}):");

            foreach (IComponent component in _components)
            {
                sb.AppendLine($"  {component}");
            }

            if (this._peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals ({this._peripherals.Count}); Average Overall Performance ({0.00}):");
            }
            else
            {
                var average = this._peripherals.Average(x => x.OverallPerformance);
                sb.AppendLine($" Peripherals ({this._peripherals.Count}); Average Overall Performance ({average:F2}):");

                foreach (var peripheral in _peripherals)
                {
                    sb.AppendLine($"  {peripheral}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
