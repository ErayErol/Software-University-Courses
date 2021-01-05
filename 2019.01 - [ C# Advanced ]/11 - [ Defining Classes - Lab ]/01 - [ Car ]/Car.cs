namespace CarManufacturer
{
    using System;

    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $"Make: {this.Make}" + Environment.NewLine +
                   $"Model: {this.Model}" + Environment.NewLine +
                   $"Year: {this.Year}";
        }
    }
}