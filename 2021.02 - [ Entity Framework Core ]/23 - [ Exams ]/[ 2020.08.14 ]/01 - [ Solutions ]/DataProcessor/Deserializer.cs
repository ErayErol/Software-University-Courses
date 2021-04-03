namespace SoftJail.DataProcessor
{
    using SoftJail.Data;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Utilities;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departments = JsonConvert.DeserializeObject<JSONDepartmentCell[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var departmentJson in departments)
            {
                if (IsValid(departmentJson) == false || departmentJson.Cells.All(IsValid) == false || departmentJson.Cells.Any() == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentJson.Name,
                    Cells = departmentJson.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    }).ToList()
                };

                context.Departments.Add(department);
                context.SaveChanges();

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisoners = JsonConvert.DeserializeObject<JSONPrisonerMail[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var prisonerJson in prisoners)
            {
                var isValidIncarceration = DateTime
                    .TryParseExact(prisonerJson.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var incarcerationDate);

                if (IsValid(prisonerJson) == false || prisonerJson.Mails.All(IsValid) == false || isValidIncarceration == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleaseDate = DateTime
                    .TryParseExact(prisonerJson.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);

                var prisoner = new Prisoner()
                {
                    FullName = prisonerJson.FullName,
                    Nickname = prisonerJson.Nickname,
                    Age = prisonerJson.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isValidReleaseDate ? releaseDate : (DateTime?)null,
                    Bail = prisonerJson.Bail,
                    CellId = prisonerJson.CellId,
                    Mails = prisonerJson.Mails.Select(x => new Mail()
                    {
                        Address = x.Address,
                        Description = x.Description,
                        Sender = x.Sender,
                    }).ToList()
                };

                context.Prisoners.Add(prisoner);
                context.SaveChanges();

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var officers = XmlConverter.Deserializer<XMLOfficerPrisoner>(xmlString, "Officers");
            var sb = new StringBuilder();

            foreach (var officerPrisonerXml in officers)
            {
                var enumPositionIsValid =
                    Enum.TryParse(typeof(Position), officerPrisonerXml.Position, out var position);

                var enumWeaponIsValid =
                    Enum.TryParse(typeof(Position), officerPrisonerXml.Position, out var weapon);

                if (IsValid(officerPrisonerXml) == false || enumPositionIsValid == false || position == null || enumWeaponIsValid == false || weapon == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerPrisonerXml.Name,
                    Salary = officerPrisonerXml.Money,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                    DepartmentId = officerPrisonerXml.DepartmentId,
                    OfficerPrisoners = officerPrisonerXml.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    }).ToList()
                };

                context.Officers.Add(officer);
                context.SaveChanges();

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}