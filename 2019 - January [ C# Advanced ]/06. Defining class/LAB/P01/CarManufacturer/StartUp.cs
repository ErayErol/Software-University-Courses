namespace CarManufacturer
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "BMW";
            car.Model = "E92";
            car.Year = 2008;

            Console.WriteLine(car);
        }
    }
}