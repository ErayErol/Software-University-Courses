using Microsoft.EntityFrameworkCore;

using ProductCatalog.Infrastucture.Data.Model;

namespace ProductCatalog.Infrastucture.Data
{
   public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
