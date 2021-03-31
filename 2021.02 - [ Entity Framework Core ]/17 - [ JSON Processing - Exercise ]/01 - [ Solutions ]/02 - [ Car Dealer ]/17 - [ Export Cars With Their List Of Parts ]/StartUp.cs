namespace CarDealer
{
    using CarDealer.Data;

    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            var result = GetCarsWithTheirListOfParts(context);
            Console.WriteLine(result);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance,
                    },
                    parts = x.PartCars
                        .Where(p => p.CarId == x.Id)
                        .Select(p => new
                        {
                            p.Part.Name,
                            Price = p.Part.Price.ToString("F2")
                        }).ToList()
                })
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return jsonOutput;
        }
    }
}