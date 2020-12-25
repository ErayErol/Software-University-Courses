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
            car.Year = 2006;
            car.FuelQuantity = 63;
            car.FuelConsumption = 13;
            car.Drive(100);
            Console.WriteLine(car.WhoAmI());
        }
    }
}