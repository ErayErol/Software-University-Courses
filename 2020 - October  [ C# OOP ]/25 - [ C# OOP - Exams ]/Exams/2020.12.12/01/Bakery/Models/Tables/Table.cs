namespace Bakery.Models.Tables
{
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;

            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public int TableNumber { get; }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price 
            => this.PricePerPerson * this.NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            var foodsTotalPrice = this.foodOrders
                .Sum(f => f.Price);

            var drinksTotalPrice = this.drinkOrders
                .Sum(d => d.Price);

            var totalBill = foodsTotalPrice + drinksTotalPrice + this.Price;

            return totalBill;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();

            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
