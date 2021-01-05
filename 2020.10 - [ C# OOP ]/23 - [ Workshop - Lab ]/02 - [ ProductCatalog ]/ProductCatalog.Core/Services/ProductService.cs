using ProductCatalog.Core.Contracts;
using ProductCatalog.Infrastucture.Data.Common;
using ProductCatalog.Infrastucture.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repo;
        public ProductService(IRepository repo)
        {
            this._repo = repo;
        }
        public IEnumerable<Product> GetProducts()
        {
            return this._repo.All<Product>().AsEnumerable();
        }

        public void Save(Product product)
        {
            if (product.Id==0)
            {
                this._repo.Add(product);
            }
            else
            {
                this._repo.Update(product);
            }
            this._repo.SaveChanges();

        }
    }
}
