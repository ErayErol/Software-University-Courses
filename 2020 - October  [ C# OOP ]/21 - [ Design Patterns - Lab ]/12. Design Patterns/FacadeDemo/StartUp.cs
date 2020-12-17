namespace FacadeDemo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var car = new CarBuilderFacade()
                .Info
                  .WithType("BMW")
                  .WithColor("Black")
                  .WithNumberOfDoors(5)
                .Built
                  .InCity("Leipzig ")
                  .AtAddress("Some address 254")
                .Build();

            Console.WriteLine(car);
        }
    }
}
