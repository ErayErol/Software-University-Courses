namespace OnlineShop.Core
{
    using Models.Products.Components;
    using Models.Products.Computers;
    using Models.Products.Peripherals;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private readonly Dictionary<int, IComputer> _computers;

        public Controller()
        {
            this._computers = new Dictionary<int, IComputer>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this._computers.ContainsKey(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer = null;

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            this._computers.Add(computer.Id, computer);
            return $"Computer with id {id} added successfully.";

        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            if (this._computers.ContainsKey(computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var isExistComponent = this._computers[computerId].Components.FirstOrDefault(x => x.Id == id);

            if (isExistComponent != null)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            this._computers[computerId].AddComponent(component);
            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (this._computers.ContainsKey(computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var component = this._computers[computerId].RemoveComponent(componentType);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            if (this._computers.ContainsKey(computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var isExist = this._computers[computerId].Peripherals.FirstOrDefault(x => x.Id == id);

            if (isExist != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            this._computers[computerId].AddPeripheral(peripheral);
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (this._computers.ContainsKey(computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var peripheral = this._computers[computerId].RemovePeripheral(peripheralType);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        public string BuyComputer(int id)
        {
            if (this._computers.ContainsKey(id) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var computer = this._computers[id];
            this._computers.Remove(id);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var isEnoughBudget = this._computers.Values.FirstOrDefault(x => x.Price <= budget);

            if (isEnoughBudget == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            var computersWithEnoughBudget = this._computers.Values.Where(x => x.Price <= budget);

            var computerWithHighestOverallPerformance =
                computersWithEnoughBudget.Select(x => x.OverallPerformance).Max();

            var computer = this._computers.Values.FirstOrDefault(x => x.OverallPerformance == computerWithHighestOverallPerformance);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (this._computers.ContainsKey(id) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var computer = this._computers[id];

            return computer.ToString();
        }
    }
}
