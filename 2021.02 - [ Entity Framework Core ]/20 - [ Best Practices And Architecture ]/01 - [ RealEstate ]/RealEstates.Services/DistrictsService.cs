using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictsService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districtInfoDtos = dbContext.Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                //.Select(x => new DistrictInfoDto
                //{
                //    Name = x.Name,
                //    PropertiesCount = x.Properties.Count,
                //    AveragePricePerSquareMeter = x
                //        .Properties
                //        .Where(p => p.Price.HasValue)
                //        .Average(p => p.Price / (decimal)p.Size) ?? 0,
                //})
                .OrderByDescending(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();

            return districtInfoDtos;
        }
    }
}