using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

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

        // var prisoners = context.Prisoners
        // .Include(x => x.PrisonerOfficers)
        // .ThenInclude(x => x.Officer)
        // .Where(x => ids.Contains(x.Id))
        // .Select(x => new
        // {
        // x.Id,
        // Name = x.FullName,
        // CellNumber = x.Cell.CellNumber,
        // Officers = x.PrisonerOfficers.Select(p => new
        // {
        // OfficerName = p.Officer.FullName,
        // Department = p.Officer.Department.Name,
        // })
        // .OrderBy(p => p.OfficerName)
        // .ToList(),
        // TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(po => po.Officer.Salary).ToString("F2"))
        // })
        // .OrderBy(x => x.Name)
        // .ThenBy(x => x.Id)
        // .ToList();
        // 
        // var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        // return json;
        // 

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            return "TODO";
        }
    }
}