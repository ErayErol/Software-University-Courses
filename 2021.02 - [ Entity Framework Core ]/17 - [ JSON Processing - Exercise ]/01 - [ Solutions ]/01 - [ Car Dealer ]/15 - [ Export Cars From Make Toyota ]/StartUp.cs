namespace CarDealer
{
    using CarDealer.Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            var result = GetCarsFromMakeToyota(context);
            //File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x=>x.Make == "Toyota")
                .Select(x => new 
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x=>x.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }
    }
}