namespace SoftUniParking
{
    using System;

    public class Car
    {
        // 1.0 Правим текущият клас да е => public
        // 2.0 First, write a C# class Car with the following properties: (може да се направят и field-ове за свикване, но се задължителни)
        // 2.1 •	Make: string
        // 2.2 •	Model: string
        // 2.3 •	HorsePower: int
        // 2.4 •	RegistrationNumber: string

        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;
        // 3.0 хващаме тези field-ове => ALT + ENTER => Encapsulate fields (and use properties)

        // 5.0 The class constructor should receive make, model, horsePower and registrationNumber 
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }
        // 5.1 слагаме this пред propertie-тата

        public string Make { get => this.make; set => this.make = value; }
        public string Model { get => this.model; set => this.model = value; }
        public int HorsePower { get => this.horsePower; set => this.horsePower = value; }
        public string RegistrationNumber { get => this.registrationNumber; set => this.registrationNumber = value; }
        // 4.0 слагаме this пред field-овете
        // 4.1 хващаме тези propertie-та => ALT + ENTER => Generate constructor

        // 6.0 override the ToString() method in the following format:
        //"Make: {make}"
        //"Model: {model}"
        //"HorsePower: {horse power}"
        //"RegistrationNumber: {registration number}"

        public override string ToString()
        {
            return $"Make: {this.Make}" + Environment.NewLine +
                   $"Model: {this.Model}" + Environment.NewLine +
                   $"HorsePower: {this.HorsePower}" + Environment.NewLine +
                   $"RegistrationNumber: {this.RegistrationNumber}";
        }
    }
}