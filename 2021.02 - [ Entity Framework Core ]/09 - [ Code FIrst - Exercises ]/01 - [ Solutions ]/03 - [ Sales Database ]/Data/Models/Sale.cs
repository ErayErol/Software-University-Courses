namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}