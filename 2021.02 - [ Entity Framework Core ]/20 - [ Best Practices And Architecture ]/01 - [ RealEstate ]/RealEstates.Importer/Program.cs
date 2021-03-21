using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var apartmentsJson = "apartments.json";
            var housesJson = "houses.json";

            ImportJson(apartmentsJson);
            Console.WriteLine();
            ImportJson(housesJson);
        }

        private static void ImportJson(string fileName)
        {
            var dbContext = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(dbContext);

            IEnumerable<PropertyAsJson> properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(File.ReadAllText(fileName));
            foreach (var jsonProp in properties)
            {
                propertiesService.Add(
                    jsonProp.District,
                    jsonProp.Floor,
                    jsonProp.TotalFloors,
                    jsonProp.Size,
                    jsonProp.YardSize,
                    jsonProp.Year,
                    jsonProp.Type,
                    jsonProp.BuildingType,
                    jsonProp.Price);
                Console.Write('.');
            }


        }
    }
}
