using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IDistrictsService
    {
        IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count);
    }
}
