namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Store
    {
        public Store()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int StoreId { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}