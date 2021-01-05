namespace OnlineShop.Core
{
    using OnlineShop.Common.Constants;
    using OnlineShop.Common.Enums;
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Computers;
    using OnlineShop.Models.Products.Peripherals;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private Dictionary<int, IComputer> computers;

        public Controller()
        {
            this.computers = new Dictionary<int, IComputer>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            var msg = ExceptionMessages.ExistingComputerId;
            if (this.computers.ContainsKey(id))
            {
                return msg;
            }

            if (Enum.TryParse(computerType, out ComputerType enumComputerType) == false)
            {
                msg = string.Format(ExceptionMessages.InvalidComputerType);
                throw new ArgumentException(msg);
            }

            IComputer computer = enumComputerType switch
            {
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
            };

            this.computers.Add(id, computer);

            msg = string.Format(SuccessMessages.AddedComputer, id);
            return msg;
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            var msg = ExceptionMessages.NotExistingComputerId;
            if (this.computers.ContainsKey(computerId) == false)
            {
                return msg;
            }

            if (this.computers[computerId].Components.FirstOrDefault(x => x.Id == id) != null)
            {
                msg = string.Format(ExceptionMessages.ExistingComponentId);
                throw new ArgumentException(msg);
            }

            if (Enum.TryParse(componentType, out ComponentType enumComponentType) == false)
            {
                msg = string.Format(ExceptionMessages.InvalidComponentType);
                throw new ArgumentException(msg);
            }

            IComponent component = enumComponentType switch
            {
                ComponentType.CentralProcessingUnit
                    => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard
                    => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply
                    => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory
                    => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive
                    => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard
                    => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
            };

            this.computers[computerId].AddComponent(component);

            msg = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            return msg;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var msg = ExceptionMessages.NotExistingComputerId;
            if (this.computers.ContainsKey(computerId) == false)
            {
                return msg;
            }

            var component = this.computers[computerId].RemoveComponent(componentType);

            msg = string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            return msg;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            var msg = ExceptionMessages.NotExistingComputerId;
            if (this.computers.ContainsKey(computerId) == false)
            {
                return msg;
            }

            if (this.computers[computerId].Peripherals.FirstOrDefault(x => x.Id == id) != null)
            {
                msg = string.Format(ExceptionMessages.ExistingPeripheralId);
                throw new ArgumentException(msg);
            }

            if (Enum.TryParse(peripheralType, out PeripheralType enumPeripheralType) == false)
            {
                msg = string.Format(ExceptionMessages.InvalidPeripheralType);
                throw new ArgumentException(msg);
            }

            IPeripheral peripheral = enumPeripheralType switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
            };

            this.computers[computerId].AddPeripheral(peripheral);

            msg = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            return msg;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var msg = ExceptionMessages.NotExistingComputerId;
            if (this.computers.ContainsKey(computerId) == false)
            {
                return msg;
            }

            var peripheral = this.computers[computerId].RemovePeripheral(peripheralType);

            msg = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
            return msg;
        }

        public string BuyComputer(int id)
        {
            var msg = ExceptionMessages.NotExistingComputerId;
            if (this.computers.ContainsKey(id) == false)
            {
                return msg;
            }

            var computer = this.computers[id];
            this.computers.Remove(id);

            msg = computer.ToString();
            return msg;
        }

        public string BuyBest(decimal budget)
        {
            /* Removes the computer with the highest overall performance and with a price, less or equal to the budget, from the collection of computers.
               
            If there are not any computers in the collection or the budget is insufficient for any computer, throws an ArgumentException with the message " Can't buy a computer with a budget of ${budget}."
            
            If it's successful, it returns ToString method on the removed computer. */

            var msg = string.Format(ExceptionMessages.CanNotBuyComputer, budget);

            var enoughBudget = this.computers.Values.Where(x => x.Price <= budget);
            if (enoughBudget.Count() == 0 || this.computers.Count == 0)
            {
                throw new ArgumentException(msg);
            }

            var computer= enoughBudget.OrderByDescending(x => x.OverallPerformance).First();

            msg = computer.ToString();
            this.computers.Remove(computer.Id);
            return msg;
        }

        public string GetComputerData(int id)
        {
            var msg = ExceptionMessages.NotExistingComputerId;
            if (this.computers.ContainsKey(id) == false)
            {
                return msg;
            }

            var computer = this.computers[id];

            msg = computer.ToString();
            return msg;
        }
    }
}
