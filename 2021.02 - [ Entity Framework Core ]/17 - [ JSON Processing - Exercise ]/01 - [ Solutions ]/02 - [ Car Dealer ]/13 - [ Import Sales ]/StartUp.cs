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
            var json = File.ReadAllText("../../../Datasets/sales.json");
            var result = ImportSales(context, json);
            Console.WriteLine(result);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDto = JsonConvert.DeserializeObject<IEnumerable<ImportSalesInputModel>>(inputJson);
            var sales = salesDto.Select(x => new Sale()
            {
                Discount = x.Discount,
                CustomerId = x.CustomerId,
                CarId = x.CarId
            }).ToList();

            context.AddRange(sales);
            context.SaveChanges();
            var result = $"Successfully imported {sales.Count()}.";
            return result;
        }
    }
}