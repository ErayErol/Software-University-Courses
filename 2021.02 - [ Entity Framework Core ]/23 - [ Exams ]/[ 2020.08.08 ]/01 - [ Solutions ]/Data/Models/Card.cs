namespace VaporStore.Data.Models
{
    using VaporStore.Data.Models.Enums;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Card
    {
        public Card()
        {
            this.Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Cvc { get; set; }

        public CardType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}