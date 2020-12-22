namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using System.Linq;

    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name) 
            => base.Models.FirstOrDefault(x => x.Model == name);
    }
}
