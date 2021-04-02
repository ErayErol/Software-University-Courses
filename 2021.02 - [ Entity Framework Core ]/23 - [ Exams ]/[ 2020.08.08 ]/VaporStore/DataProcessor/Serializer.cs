using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using ProductShop.Utilities;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
    using Data;
    using System;

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
                .Where(x => x.Cards.Any(c=>c.Purchases.Any()))
                .Select(x => new UserXmlOutputModel
                {
                    Username = x.Username,
                    Purchases = context.Purchases
                        .Where(p => p.Card.UserId == x.Id && p.Type.ToString() == storeType)
                        .Select(p => new PurchaseXmlOutputModel()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameXmlOutputModel()
                            {
                                Genre = p.Game.Genre.Name,
                                Title = p.Game.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(s => s.Date)
                        .ToArray(),
                    TotalSpent = context.Purchases
                        .Where(p => p.Card.UserId == x.Id).Sum(p => p.Game.Price)
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            var result = XmlConverter.Serialize(users, "Users");
            return result;
        }
    }
}