using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstates.Data;
using RealEstates.Models;

namespace RealEstates.Services
{
    public class TagsService : BaseService, ITagsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPropertiesService propertiesService;

        public TagsService(ApplicationDbContext dbContext, IPropertiesService propertiesService)
        {
            this.dbContext = dbContext;
            this.propertiesService = propertiesService;
        }

        public void Add(string name, int? importance)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance
            };

            this.dbContext.Tags.Add(tag);
            this.dbContext.SaveChanges();
        }

        public void BulkTagToPropertiesRelation()
        {
            var allProperties = dbContext.Properties.ToList();

            foreach (var property in allProperties)
            {
                var averagePriceForDistrict = this.propertiesService.AveragePricePerSquareMeter(property.DistrictId);
                if (property.Price >= averagePriceForDistrict)
                {
                    var tag = GetTag("скъп");
                    property.Tags.Add(tag);
                }
                else if (property.Price < averagePriceForDistrict)
                {
                    var tag = GetTag("евтин");
                    property.Tags.Add(tag);
                }

                var currentDate = DateTime.Now.AddYears(-15);
                if (property.Year.HasValue && property.Year <= currentDate.Year)
                {
                    var tag = GetTag("старо-строителство");
                    property.Tags.Add(tag);
                }
                else if (property.Year.HasValue && property.Year > currentDate.Year)
                {
                    var tag = GetTag("ново-строителство");
                    property.Tags.Add(tag);
                }

                var averagePropertySize = this.propertiesService.AverageSize(property.DistrictId);
                if (property.Size >= averagePropertySize)
                {
                    var tag = GetTag("голям");
                    property.Tags.Add(tag);
                }
                else if (property.Year.HasValue && property.Year > currentDate.Year)
                {
                    var tag = GetTag("малък");
                    property.Tags.Add(tag);
                }

                if (property.Floor.HasValue && property.Floor.Value == 1)
                {
                    var tag = GetTag("първи-етаж");
                    property.Tags.Add(tag);
                }
                else if (property.Floor.HasValue && property.Floor.Value > 10)
                {
                    var tag = GetTag("прекрасна-гледка");
                    property.Tags.Add(tag);
                } 
            }

            dbContext.SaveChanges();
        }

        private Tag GetTag(string tagName)
            => dbContext.Tags.FirstOrDefault(x => x.Name == tagName);
    }
}
