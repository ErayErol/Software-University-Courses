namespace NeedForSpeed
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var vehicle = new Car(380, 20);
            vehicle.Drive(100);
            //vehicle.Drive(50);
            //vehicle.Drive(30);
            Console.WriteLine(vehicle.Fuel);
        }
    }
}
