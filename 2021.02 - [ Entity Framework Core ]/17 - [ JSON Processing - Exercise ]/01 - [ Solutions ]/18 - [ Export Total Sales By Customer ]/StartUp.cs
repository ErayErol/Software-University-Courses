using System.IO;
using Newtonsoft.Json.Serialization;

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
            var result = GetTotalSalesByCustomer(context);
            File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sales = context.Sales.Select(x => new { x.CustomerId, SpentMoney = x.Car.PartCars.Sum(z => z.Part.Price) });
            var customers = context
                .Customers
                .Where(c => sales.Count(s => s.CustomerId == c.Id) > 0)
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = sales.Count(s => s.CustomerId == x.Id),
                    SpentMoney = sales.Where(z => z.CustomerId == x.Id).Sum(s => s.SpentMoney)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            DefaultContractResolver contractResolver =
                new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return json;

        }
    }
}