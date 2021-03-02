namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}