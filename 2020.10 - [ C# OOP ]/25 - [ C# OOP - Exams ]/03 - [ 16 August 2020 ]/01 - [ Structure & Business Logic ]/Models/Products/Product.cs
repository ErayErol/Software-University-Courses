namespace OnlineShop.Models.Products
{
    using System;

    public abstract class Product : IProduct
    {
        private const int MIN_VALUE = 0;

        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => id;
            private set
            {
                if (value <= MIN_VALUE)
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidProductId);
                }
                id = value;
            }
        }

        public string Manufacturer
        {
            get => manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidManufacturer);
                }
                manufacturer = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidModel);
                }
                model = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            private set
            {
                if (value <= MIN_VALUE)
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidPrice);
                }
                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => overallPerformance;
            private set
            {
                if (value <= MIN_VALUE)
                {
                    throw new ArgumentException(Common.Constants.ExceptionMessages.InvalidOverallPerformance);
                }
                overallPerformance = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format(Common.Constants.SuccessMessages.ProductToString, $"{this.OverallPerformance:F2}",
                $"{this.Price:F2}", this.GetType().Name, this.Manufacturer, this.Model, this.Id);
            return result;
        }
    }
}
