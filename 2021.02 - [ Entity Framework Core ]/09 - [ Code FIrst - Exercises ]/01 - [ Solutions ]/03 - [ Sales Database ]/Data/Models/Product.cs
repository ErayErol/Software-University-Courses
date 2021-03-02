namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}