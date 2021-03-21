using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RealEstates.Services.Profiler;

namespace RealEstates.Services
{
    public class BaseService
    {
        public BaseService()
        {
            InitializeAutoMapper();
        }

        protected IMapper Mapper { get; private set; }

        private void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RealEstateProfiler>();
            });

            this.Mapper = config.CreateMapper();
        }
    }
}
