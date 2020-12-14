namespace Bakery.Models.BakedFoods
{
    using Contracts;
    using System;

    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public int Portion
        {
            get
            {
                return portion;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPortion);
                }

                this.portion = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Portion}g - {this.Price:F2}";
        }
    }
}
