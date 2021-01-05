using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Infrastucture.Data.Model
{
   public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
