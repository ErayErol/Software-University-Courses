namespace VaporStore.Data.Models
{
    using VaporStore.Data.Models.Enums;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchase
    {
        public int Id { get; set; }

        public PurchaseType Type { get; set; }

        [Required]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}