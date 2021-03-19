using System.Collections.Generic;
using CarDealer.Utillities;

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
            string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            string result = ImportCustomers(context, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
            //CustomerInputModel[] customerInputModels = serializer.Deserialize(new StringReader(inputXml)) as CustomerInputModel[];
            const string root = "Customers";
            CustomerInputModel[] customerInputModels = XmlConverter.Deserializer<CustomerInputModel>(inputXml, root);
            Customer[] customers = customerInputModels
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                }).ToArray();

            context.AddRange(customers);
            context.SaveChanges();
            var result = $"Successfully imported {customers.Length}";
            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            CarInputModel[] carInputModels = serializer.Deserialize(new StringReader(inputXml)) as CarInputModel[];
            var listOfCars = new List<Car>();
            var listOfPartCars = new List<PartCar>();
            var existsParts = context.Parts.Select(x => x.Id);

            foreach (var carInputModel in carInputModels)
            {
                var currentCar = new Car()
                {
                    Make = carInputModel.Make,
                    Model = carInputModel.Model,
                    TravelledDistance = carInputModel.TravelledDistance,
                };

                foreach (var partId in carInputModel.parts.Where(z => existsParts.Contains(z.id)).Select(z => z.id).Distinct())
                {
                    var currentPartCar = new PartCar()
                    {
                        //CarId = currentCar.Id,
                        PartId = partId
                    };
                    currentCar.PartCars.Add(currentPartCar);
                    listOfPartCars.Add(currentPartCar);
                }

                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.PartCars.AddRange(listOfPartCars);
            context.SaveChanges();
            var result = $"Successfully imported {listOfCars.Count}";
            return result;
        }
    }
}