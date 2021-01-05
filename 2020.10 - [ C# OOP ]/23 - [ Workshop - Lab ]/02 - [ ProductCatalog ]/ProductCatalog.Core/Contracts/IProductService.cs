using System.Collections.Generic;

using ProductCatalog.Infrastucture.Data.Model;

namespace ProductCatalog.Core.Contracts
{
   public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        void Save(Product product);
    }
}
