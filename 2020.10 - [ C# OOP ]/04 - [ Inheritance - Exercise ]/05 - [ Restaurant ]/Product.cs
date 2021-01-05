namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
