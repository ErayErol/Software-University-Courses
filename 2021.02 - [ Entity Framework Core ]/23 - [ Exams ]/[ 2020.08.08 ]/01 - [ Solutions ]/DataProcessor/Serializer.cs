namespace VaporStore.DataProcessor
{
    using Data;
    using Dto.Export;
    using Utilities;

    using Newtonsoft.Json;
    using System.Globalization;
    using System.Linq;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .ToList()
                .Where(genre => genreNames.Contains(genre.Name))
                .Select(genre => new
                {
                    genre.Id,
                    Genre = genre.Name,
                    Games = genre.Games
                        .Select(game => new
                        {
                            game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(gameTag => gameTag.Tag.Name)),
                            Players = game.Purchases.Count
                        })
                        .Where(game => game.Players > 0)
                        .OrderByDescending(s => s.Players)
                        .ThenBy(s => s.Id)
                        .ToList(),
                    TotalPlayers = genre.Games.Sum(game => game.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id);


            var json = JsonConvert.SerializeObject(genres, Formatting.Indented);
            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .AsEnumerable()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(s => s.Type.ToString() == storeType)))
                .Select(x => new UserXmlOutputModel
                {
                    Username = x.Username,
                    Purchases = x.Cards
                        .SelectMany(c => c.Purchases.Where(p => p.Type.ToString() == storeType), (card, purchase) => new PurchaseXmlOutputModel
                        {
                            Card = card.Number,
                            Cvc = card.Cvc,
                            Date = purchase.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameXmlOutputModel()
                            {
                                Title = purchase.Game.Name,
                                Genre = purchase.Game.Genre.Name,
                                Price = purchase.Game.Price
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray(),
                    TotalSpent = x.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price))
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var result = XmlConverter.Serialize(users, "Users");
            return result;
        }
    }
}

//Use the method provided in the project skeleton, which receives a purchase type as a string.
//Export all users who have any purchases.
//For each user, export their username, purchases for that purchase type and total money spent for that purchase type.
//For each purchase, export its card number, CVC, date in the format "yyyy-MM-dd HH:mm" (make sure you use CultureInfo.InvariantCulture) and the game.
//For each game, export its title (name), genre and price.
//Order the users by total spent (descending), then by username (ascending). For each user, order the purchases by date (ascending).
//Do not export users, who don’t have any purchases.
// Note: All prices must be in decimal without any formatting!
// 