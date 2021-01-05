using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DefaulGrams = 250;
        private const double DefaulCalories = 1000;
        private const decimal DefaulPrice = 5m;

        public Cake(string name)
            : base(name, DefaulPrice, DefaulGrams, DefaulCalories)
        {
        }
    }
}
