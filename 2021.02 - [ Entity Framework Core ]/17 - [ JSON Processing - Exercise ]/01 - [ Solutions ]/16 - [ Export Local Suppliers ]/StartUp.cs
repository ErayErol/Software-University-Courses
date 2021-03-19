using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

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
            var result = GetLocalSuppliers(context);
            //File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var supplier = context
                .Suppliers
                .Where(x=>x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count(p => p.SupplierId == x.Id)
                })
                .ToList();

            var json = JsonConvert.SerializeObject(supplier, Formatting.Indented);
            return json;
        }
    }
}