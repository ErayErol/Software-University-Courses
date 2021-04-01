using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserJsonModel
    {
        // •	Username – text with length [3, 20] (required)
        // •	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
        // •	Email – text (required)
        // •	Age – integer in the range [3, 103] (required)
        // •	Cards – collection of type Card
        // 

        [Required]
        [RegularExpression("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public CardJsonModel[] Cards { get; set; }
    }
}

// {
// "FullName": "",
// "Username": "invalid",
// "Email": "invalid@invalid.com",
// "Age": 20,
// "Cards": [
// {
// "Number": "1111 1111 1111 1111",
// "CVC": "111",
// "Type": "Debit"
// }
// ]
// }