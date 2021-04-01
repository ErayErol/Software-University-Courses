using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Utilities;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;
using Card = VaporStore.Data.Models.Card;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var games = JsonConvert.DeserializeObject<GameJsonModel[]>(jsonString);

            var output = new StringBuilder();
            foreach (var jsonGame in games)
            {
                if (IsValid(jsonGame) == false || jsonGame.Tags.All(IsValid) == false || jsonGame.Tags.Length == 0)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var dev = context.Developers.FirstOrDefault(x => x.Name == jsonGame.Developer) ?? new Developer()
                {
                    Name = jsonGame.Developer
                };

                var genre = context.Genres.FirstOrDefault(x => x.Name == jsonGame.Genre) ?? new Genre()
                {
                    Name = jsonGame.Genre
                };

                var game = new Game
                {
                    Name = jsonGame.Name,
                    Price = jsonGame.Price,
                    ReleaseDate = DateTime.ParseExact(jsonGame.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = dev,
                    Genre = genre,
                };

                foreach (var tagName in jsonGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == tagName) ?? new Tag()
                    {
                        Name = tagName
                    };

                    game.GameTags.Add(new GameTag { Tag = tag });
                }

                context.Games.Add(game);
                context.SaveChanges();
                output.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            var result = output.ToString().TrimEnd();
            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var users = JsonConvert.DeserializeObject<UserJsonModel[]>(jsonString);

            var output = new StringBuilder();
            foreach (var jsonUser in users)
            {
                if (IsValid(jsonUser) == false || jsonUser.Cards.All(IsValid) == false)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    FullName = jsonUser.FullName,
                    Username = jsonUser.Username,
                    Email = jsonUser.Email,
                    Age = jsonUser.Age,
                    Cards = jsonUser.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.CVC,
                        Type = Enum.Parse<CardType>(x.Type)
                    }).ToArray()
                };

                context.Users.Add(user);
                context.SaveChanges();
                output.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            var result = output.ToString().TrimEnd();
            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            const string root = "Purchases";
            var purchases = XmlConverter.Deserializer<PurchaseXmlModel>(xmlString, root);
            var output = new StringBuilder();

            foreach (var xmlPurchase in purchases)
            {
                if (IsValid(xmlPurchase) == false)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == xmlPurchase.Card);
                var user = context.Users.Select(x => new { x.Id, x.Username }).FirstOrDefault(x => x.Id == card.UserId);
                var game = context.Games.FirstOrDefault(x => x.Name == xmlPurchase.Title);

                var purchase = new Purchase()
                {
                    Type = Enum.Parse<PurchaseType>(xmlPurchase.Type),
                    ProductKey = xmlPurchase.ProductKey,
                    Card = card,
                    Date = DateTime.ParseExact(xmlPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = game,
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
                output.AppendLine($"Imported {game.Name} for {user.Username}");
            }

            var result = output.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}