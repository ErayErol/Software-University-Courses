namespace CarDealer
{
    using CarDealer.Data;

    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            var result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Include(x => x.Car)
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("F2"),
                    price = x.Car.PartCars.Sum(c => c.Part.Price).ToString("F2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(c => c.Part.Price) - (x.Car.PartCars.Sum(c => c.Part.Price) * (x.Discount) / 100.0m)).ToString("F2"),
                })
                .Take(10)
                .ToList();

            var jsonOutput = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return jsonOutput;
        }
    }
}