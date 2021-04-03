namespace SoftJail.DataProcessor
{
    using SoftJail.Data;
    using SoftJail.DataProcessor.ExportDto;
    using SoftJail.Utilities;

    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Include(x => x.PrisonerOfficers)
                .ThenInclude(x => x.Officer)
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(p => new
                    {
                        OfficerName = p.Officer.FullName,
                        Department = p.Officer.Department.Name,
                    })
                        .OrderBy(p => p.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(po => po.Officer.Salary).ToString("F2"))
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);
            return json;

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context.Prisoners
                .Where(x => names.Contains(x.FullName))
                .Select(x => new PrisonerViewModel
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(m => new EncryptedMessageViewModel
                    {
                        Description = string.Join("", m.Description.Reverse())
                    }).ToArray() // must be array
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var result = XmlConverter.Serialize(prisoners, "Prisoners");
            return result;
        }
    }


}