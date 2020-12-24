using System;
using System.Linq;

namespace ProductCatalog.Infrastucture.Data.Common
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class;

        void Add<T>(T entity) where T : class;

        T GetById<T>(object id) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void Delete<T>(object id) where T : class;

        int SaveChanges();
    }
}
