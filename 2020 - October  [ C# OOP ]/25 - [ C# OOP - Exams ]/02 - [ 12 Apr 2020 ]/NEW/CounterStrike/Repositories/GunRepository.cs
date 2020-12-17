using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        /* The gun repository is a repository for all guns in the game.
           Data
           •	Models - a collection of guns (unmodifiable)
           Behavior
           void Add(Gun gun)
           •	If the gun is null, throw an ArgumentException with message: "Cannot add null in Gun Repository".
           •	Adds a gun in the collection.
           bool Remove(Gun gun)
           •	Removes a gun from the collection. Returns true if the removal was sucessful, otherwise - false.
           Gun FindByName(string name)
           •	Returns the first gun with the given name, if there is such gun. Otherwise, returns null.
            */

        private readonly ICollection<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
            => this.guns.ToList().AsReadOnly();

        public void Add(IGun model)
        {
            // TODO: Check this
            if (model == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(model);
        }

        public bool Remove(IGun model)
            => this.guns.Remove(model);

        public IGun FindByName(string name) 
            => this.guns.FirstOrDefault(x => x.Name == name);
    }
}
