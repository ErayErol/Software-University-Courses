namespace BookShop.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorJSON
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{3}-[\d]{3}-[\d]{4}$")]
        public string Phone { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public BookJSON[] Books { get; set; }
    }
}