using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Infrastucture.Data.Common
{
    public class Repository : IRepository
    {
        protected DbContext Context { get; set; }

        public Repository(ApplicationDBContext context)
        {
            this.Context = context;
        }

        protected DbSet<T> DbSet<T>() where T:class
        {
            return this.Context.Set<T>();
        }
        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable<T>();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public T GetById<T>(object id) where T : class
        {
            return DbSet<T>().Find();
        }

        public int SaveChanges()
        {
           return Context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
        }
    }
}
