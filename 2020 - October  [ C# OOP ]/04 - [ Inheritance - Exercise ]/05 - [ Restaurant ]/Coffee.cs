namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Coffee : HotBeverage
    {
        private const double DefaulMilliliters = 50;
        private const decimal DefaulPrice = 3.50m;

        public Coffee(string name, double caffeine)
            : base(name, DefaulPrice, DefaulMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
