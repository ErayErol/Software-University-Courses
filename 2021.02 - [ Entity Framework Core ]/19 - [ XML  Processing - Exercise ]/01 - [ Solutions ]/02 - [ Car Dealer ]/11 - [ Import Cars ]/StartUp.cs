using System.Collections.Generic;

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
            string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            string result = ImportCars(context, inputXml);
            Console.WriteLine(result);
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