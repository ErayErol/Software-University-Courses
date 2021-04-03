namespace VaporStore.DataProcessor
{
    using VaporStore.Data;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.Utilities;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var games = JsonConvert.DeserializeObject<JSONGame[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var jsonGame in games)
            {
                var isValidDate = DateTime.TryParseExact(jsonGame.ReleaseDate,
                    "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);

                if (IsValid(jsonGame) == false || jsonGame.Tags.All(IsValid) == false || jsonGame.Tags.Length == 0 || isValidDate == false)
                {
                    sb.AppendLine("Invalid Data");
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
                    ReleaseDate = releaseDate,
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
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var users = JsonConvert.DeserializeObject<JSONUser[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var jsonUser in users)
            {
                if (IsValid(jsonUser) == false || jsonUser.Cards.All(IsValid) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    FullName = jsonUser.FullName,
                    Username = jsonUser.Username,
                    Email = jsonUser.Email,
                    Age = jsonUser.Age,
                };

                foreach (var jsonUserCard in jsonUser.Cards)
                {
                    var isValidEnum = Enum
                        .TryParse(typeof(CardType), jsonUserCard.Type, out var type);

                    if (isValidEnum && type != null)
                    {
                        var card = new Card()
                        {
                            Number = jsonUserCard.Number,
                            Cvc = jsonUserCard.CVC,
                            Type = (CardType)type
                        };

                        user.Cards.Add(card);
                    }
                }

                context.Users.Add(user);
                context.SaveChanges();

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var purchases = XmlConverter.Deserializer<XMLPurchase>(xmlString, "Purchases");
            var sb = new StringBuilder();

            foreach (var purchaseXml in purchases)
            {
                var isValidDate = DateTime
                    .TryParseExact(purchaseXml.Date, "dd/MM/yyyy HH:mm",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

                var isValidEnum = Enum
                    .TryParse(typeof(PurchaseType), purchaseXml.Type, out var type);

                if (IsValid(purchaseXml) == false || isValidDate == false || isValidEnum == false || type == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseXml.Card);
                var user = context.Users.Select(x => new { x.Id, x.Username }).FirstOrDefault(x => x.Id == card.UserId);
                var game = context.Games.FirstOrDefault(x => x.Name == purchaseXml.Title);

                var purchase = new Purchase()
                {
                    Type = (PurchaseType)type,
                    ProductKey = purchaseXml.ProductKey,
                    Card = card,
                    Date = date,
                    Game = game,
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
                sb.AppendLine($"Imported {game.Name} for {user.Username}");
            }

            var result = sb.ToString().TrimEnd();
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