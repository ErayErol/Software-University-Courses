using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardJsonModel
    {
        // •	Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. “1234 5678 9012 3456”) (required)
        // •	Cvc – text, which consists of 3 digits (ex. “123”) (required)
        // •	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)
        
        [Required]
        [RegularExpression(@"[\d]{4} [\d]{4} [\d]{4} [\d]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[\d]{3}")]
        public string CVC { get; set; }

        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }
    }
}