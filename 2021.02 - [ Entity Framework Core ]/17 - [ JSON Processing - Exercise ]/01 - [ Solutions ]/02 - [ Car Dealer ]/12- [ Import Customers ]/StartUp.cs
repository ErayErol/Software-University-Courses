namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            var json = File.ReadAllText("../../../Datasets/customers.json");
            var result = ImportCustomers(context, json);
            Console.WriteLine(result);
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<IEnumerable<ImportCustomerInputModel>>(inputJson);
            var customers = customersDto.Select(x => new Customer()
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver
            }).ToList();

            context.AddRange(customers);
            context.SaveChanges();
            var result = $"Successfully imported {customers.Count()}.";
            return result;
        }
    }
}