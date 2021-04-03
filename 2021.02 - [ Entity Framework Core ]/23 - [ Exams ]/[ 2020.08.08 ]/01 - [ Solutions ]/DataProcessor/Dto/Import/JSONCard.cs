namespace VaporStore.DataProcessor.Dto.Import
{
    using VaporStore.Data.Models.Enums;

    using System.ComponentModel.DataAnnotations;

    public class JSONCard
    {
        [Required]
        [RegularExpression(@"[\d]{4} [\d]{4} [\d]{4} [\d]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[\d]{3}")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}