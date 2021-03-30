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
            var result = GetOrderedCustomers(context);
            //File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x=>x.IsYoungDriver)
                .Select(x => new 
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }
    }
}