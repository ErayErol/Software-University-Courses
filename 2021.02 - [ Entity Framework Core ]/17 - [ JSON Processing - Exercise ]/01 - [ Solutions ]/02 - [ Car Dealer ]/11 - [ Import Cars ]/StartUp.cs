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
            var json = File.ReadAllText("../../../Datasets/cars.json");
            var result = ImportCars(context, json);
            Console.WriteLine(result);
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<ImportCarsInputModel>>(inputJson);
            var listOfCars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar()
                    {
                        PartId = partId
                    });
                }

                listOfCars.Add(currentCar);
            }

            context.AddRange(listOfCars);
            context.SaveChanges();
            var result = $"Successfully imported {listOfCars.Count}.";
            return result;
        }
    }
}