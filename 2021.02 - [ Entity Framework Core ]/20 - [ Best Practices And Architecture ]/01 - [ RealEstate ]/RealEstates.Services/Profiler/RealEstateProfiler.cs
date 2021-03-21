using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services.Profiler
{
    public class RealEstateProfiler : Profile
    {
        public RealEstateProfiler()
        {
            this.CreateMap<Property, PropertyInfoDto>()
                .ForMember(x => x.BuildingType, y => y.MapFrom(s => s.BuildingType.Name))
                .ForMember(x => x.PropertyType, y => y.MapFrom(s => s.Type.Name));

            this.CreateMap<District, DistrictInfoDto>()
                .ForMember(x => x.AveragePricePerSquareMeter,
                    y => y.MapFrom(s => s.Properties
                    .Where(p => p.Price.HasValue)
                    .Average(p => p.Price / (decimal)p.Size) ?? 0));

            this.CreateMap<Property, PropertyInfoFullData>()
                .ForMember(x => x.BuildingType, y => y.MapFrom(s => s.BuildingType.Name))
                .ForMember(x => x.PropertyType, y => y.MapFrom(s => s.Type.Name));

            this.CreateMap<Tag, TagInfoDto>();
        }
    }
}
