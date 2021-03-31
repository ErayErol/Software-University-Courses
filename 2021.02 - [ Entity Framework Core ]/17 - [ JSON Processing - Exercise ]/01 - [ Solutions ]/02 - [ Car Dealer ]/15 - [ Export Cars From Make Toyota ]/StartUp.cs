namespace CarDealer
{
    using CarDealer.Data;

    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class StartUp
    {
        private const string CarMake = "Toyota";

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            var result = GetCarsFromMakeToyota(context);
            Console.WriteLine(result);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make == CarMake)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }
    }
}