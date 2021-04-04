namespace VaporStore.DataProcessor
{
    using Data;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.Utilities;

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
                .ThenBy(x => x.Id)
                .ToList();


            var result = JsonConvert.SerializeObject(genres, Formatting.Indented);
            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .ToList()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(s => s.Type.ToString() == storeType)))
                .Select(x => new XMLExportUser
                {
                    Username = x.Username,
                    Purchases = x.Cards
                        .SelectMany(c => c.Purchases.Where(p => p.Type.ToString() == storeType), (card, purchase) => new XMLExportPurchase
                        {
                            Card = card.Number,
                            Cvc = card.Cvc,
                            Date = purchase.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new XMLExportGame()
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