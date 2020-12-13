using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private string engine;
        private string weight;
        private string color;

        public Car()
        {
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public Car(string model, string engine)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Engine
        {
            get { return this.engine; }
            set { this.engine = value; }

        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}