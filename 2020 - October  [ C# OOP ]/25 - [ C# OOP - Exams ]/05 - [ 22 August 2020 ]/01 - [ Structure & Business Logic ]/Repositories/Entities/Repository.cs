namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models
            => this.models.ToList().AsReadOnly();

        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll() 
            => this.Models;

        public void Add(T model) 
            => this.models.Add(model);

        public bool Remove(T model) 
            => this.models.Remove(model);
    }
}
