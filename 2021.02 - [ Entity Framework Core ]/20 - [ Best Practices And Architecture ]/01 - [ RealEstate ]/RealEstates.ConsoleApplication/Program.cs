using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using RealEstates.Services.Models;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive district");
                Console.WriteLine("3. Add Tag");
                Console.WriteLine("4. Bulk Tag to properties");
                Console.WriteLine("5. Properties Full info");
                Console.WriteLine("0. EXIT");
                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }
                if (parsed && option >= 1 && option <= 5)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                        case 3:
                            AddTag(db);
                            break;
                        case 4:
                            BulkTagToProperties(db);
                            break;
                        case 5:
                            PropertiesFullInfo(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void PropertiesFullInfo(ApplicationDbContext db)
        {
            Console.WriteLine("Count of properties:");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService propertiesService = new PropertiesService(db);
            var result = propertiesService.GetFullData(count).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(PropertyInfoFullData[]));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, result);
            Console.WriteLine(stringWriter.ToString().TrimEnd());
        }

        private static void BulkTagToProperties(ApplicationDbContext db)
        {
            Console.WriteLine("Bulk operation stated!");
            IPropertiesService propertiesService = new PropertiesService(db);
            ITagsService tagsService = new TagsService(db, propertiesService);
            tagsService.BulkTagToPropertiesRelation();
            Console.WriteLine("Bulk operation finished!");
        }

        private static void AddTag(ApplicationDbContext db)
        {
            Console.Write("Tag name: ");
            string tagName = Console.ReadLine();

            Console.Write("Importance (optiona):");
            bool isParsed = int.TryParse(Console.ReadLine(), out int tagImportance);
            int? importance = isParsed ? tagImportance : (int?) null;

            IPropertiesService propertiesService = new PropertiesService(db);
            ITagsService tagService = new TagsService(db, propertiesService);
            tagService.Add(tagName, importance);
        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            Console.Write("Districts count: ");
            int count = int.Parse(Console.ReadLine());

            IDistrictsService districtsService = new DistrictsService(db);
            var districts = districtsService.GetMostExpensiveDistricts(count);
            foreach (var districtInfoDto in districts)
            {
                Console.WriteLine($"{districtInfoDto.Name} => {districtInfoDto.AveragePricePerSquareMeter:F2}€/m² ({districtInfoDto.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.Write("Min price: ");
            int minPrice = int.Parse(Console.ReadLine());

            Console.Write("Max price: ");
            int maxPrice = int.Parse(Console.ReadLine());

            Console.Write("Min size: ");
            int minSize = int.Parse(Console.ReadLine());

            Console.Write("Max size: ");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(db);
            IEnumerable<PropertyInfoDto> properties = service.Search(minPrice, maxPrice, minSize, maxSize);
            foreach (var propertyInfoDto in properties)
            {
                Console.WriteLine($"{propertyInfoDto.DistrictName}; {propertyInfoDto.BuildingType}; {propertyInfoDto.PropertyType} => {propertyInfoDto.Price}€ => {propertyInfoDto.Size}m²");
            }
        }
    }
}
