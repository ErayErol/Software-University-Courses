namespace CarDealer
{
    using CarDealer.Data;
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

            var json = File.ReadAllText("../../../Datasets/parts.json");
            var result = ImportParts(context, json);
            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplier = context.Suppliers.Select(x => x.Id);
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(x => supplier.Contains(x.SupplierId));

            context.AddRange(parts);
            context.SaveChanges();
            var result = $"Successfully imported {parts.Count()}.";
            return result;
        }
    }
}