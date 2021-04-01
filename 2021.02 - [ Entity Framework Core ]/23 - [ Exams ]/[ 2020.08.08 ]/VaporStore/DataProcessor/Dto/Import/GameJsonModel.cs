using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class GameJsonModel
    {
        // •	Name – text (required)
        // •	Price – decimal (non-negative, minimum value: 0) (required)
        // •	ReleaseDate – Date (required)
        // •	DeveloperId – integer, foreign key (required)
        // •	Developer – the game’s developer (required)
        // •	GenreId – integer, foreign key (required)
        // •	Genre – the game’s genre (required)
        // •	Purchases - collection of type Purchase
        // •	GameTags - collection of type GameTag. Each game must have at least one tag.

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public string[] Tags { get; set; }
    }



    [JsonArray]
    public class GameTagInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}

// {
// "Name": "MONSTER HUNTER: WORLD",
// "Price": 59.99,
// "ReleaseDate": "2018-08-09",
// "Developer": "CAPCOM Co., Ltd.",
// "Genre": "Action",
// "Tags": [
// "Single-player",
// "Multi-player",
// "Co-op",
// "Steam Achievements",
// "Partial Controller Support",
// "Stats"
// ]
// },