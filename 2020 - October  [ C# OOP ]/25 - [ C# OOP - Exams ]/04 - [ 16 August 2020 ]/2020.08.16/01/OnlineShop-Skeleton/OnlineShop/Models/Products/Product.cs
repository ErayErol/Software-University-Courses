using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private decimal _price;
        private double _overallPerformance;

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
            get
            {
                return _id;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Id can not be less or equal than 0.");
                }

                _id = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Manufacturer can not be empty.");
                }

                _manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Model can not be empty.");
                }

                _model = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return _price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Price can not be less or equal than 0.");
                }

                _price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get
            {
                return _overallPerformance;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Overall Performance can not be less or equal than 0.");
                }

                _overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
