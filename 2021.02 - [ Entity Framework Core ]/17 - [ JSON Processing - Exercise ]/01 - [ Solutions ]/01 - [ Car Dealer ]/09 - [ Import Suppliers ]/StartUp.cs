namespace CarDealer
{
    using AutoMapper;
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
            var json = File.ReadAllText("../../../Datasets/suppliers.json");
            var result = ImportSuppliers(context, json);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDto = JsonConvert.DeserializeObject<IEnumerable<ImportSuppliersInputModel>>(inputJson);
            var suppliers = suppliersDto
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();
            context.AddRange(suppliers);
            context.SaveChanges();
            var result = $"Successfully imported {suppliers.Count}.";
            return result;
        }
    }
}