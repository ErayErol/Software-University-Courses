namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            string result = ImportParts(context, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            PartInputModel[] partInputModels = serializer.Deserialize(new StringReader(inputXml)) as PartInputModel[];

            var suppliersId = context.Suppliers.Select(x => x.Id);
            Part[] parts = partInputModels
                .Where(x=>suppliersId.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                }).ToArray();

            context.AddRange(parts);
            context.SaveChanges();
            string result = $"Successfully imported {parts.Length}";
            return result;
        }
    }
}