using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(string district, int floor,
            int maxFloor, int size, int yardSize, int year,
            string propertyType, string buildingType, int price);

        decimal AveragePricePerSquareMeter();

        decimal AveragePricePerSquareMeter(int districtId);

        double AverageSize(int districtId);

        IEnumerable<PropertyInfoFullData> GetFullData(int count);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);
    }
}
