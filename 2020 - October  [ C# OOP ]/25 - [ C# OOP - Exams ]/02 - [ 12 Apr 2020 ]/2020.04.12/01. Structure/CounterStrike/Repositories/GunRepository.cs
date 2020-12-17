using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
            => this.guns;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(model);   
        }

        public IGun FindByName(string name)
            => this.guns.FirstOrDefault(g => g.Name == name);

        public bool Remove(IGun model)
        {
            var gun = this.guns.FirstOrDefault(g => g.Name == model.Name);

            if (gun == null)
            {
                return false;
            }

            this.guns.Remove(gun);
            return true;
        }
    }
}
