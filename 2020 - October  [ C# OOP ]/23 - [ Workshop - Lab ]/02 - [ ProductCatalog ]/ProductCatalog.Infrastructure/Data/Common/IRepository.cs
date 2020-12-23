using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Infrastructure.Data.Common
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() // Read
            where T : class;

        void Add<T>(T entity) // Add
            where T : class;

        T GetById<T>(object id)
            where T : class;

        void Update<T>(T entity)
            where T : class;

        void Delete<T>(T entity)
            where T : class;

        void Delete<T>(object id)
            where T : class;

        int SaveChanges();
    }
}
