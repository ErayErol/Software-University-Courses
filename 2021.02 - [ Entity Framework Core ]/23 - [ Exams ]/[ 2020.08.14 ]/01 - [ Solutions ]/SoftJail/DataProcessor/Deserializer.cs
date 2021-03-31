using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Utilities;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentCellInputModels = JsonConvert.DeserializeObject<DepartmentCellInputModel[]>(jsonString);
            var departments = new List<Department>();

            var sb = new StringBuilder();
            foreach (var departmentCellInputModel in departmentCellInputModels)
            {
                if (IsValid(departmentCellInputModel) == false || departmentCellInputModel.Cells.All(IsValid) == false || departmentCellInputModel.Cells.Any() == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentCellInputModel.Name,
                    Cells = departmentCellInputModel.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    }).ToList()
                };

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                departments.Add(department);
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var outputMsg = sb.ToString().TrimEnd();
            return outputMsg;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerMailInputModels = JsonConvert.DeserializeObject<PrisonerMailInputModel[]>(jsonString);
            var prisoners = new List<Prisoner>();

            var sb = new StringBuilder();
            foreach (var prisonerMailInputModel in prisonerMailInputModels)
            {
                if (IsValid(prisonerMailInputModel) == false || prisonerMailInputModel.Mails.All(IsValid) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime incarcerationDate = DateTime.ParseExact(prisonerMailInputModel.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var isValidReleaseDate = DateTime
                    .TryParseExact(
                        prisonerMailInputModel.ReleaseDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var releaseDate);


                var prisoner = new Prisoner()
                {
                    FullName = prisonerMailInputModel.FullName,
                    Nickname = prisonerMailInputModel.Nickname,
                    Age = prisonerMailInputModel.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = isValidReleaseDate ? releaseDate : (DateTime?)null,
                    Bail = prisonerMailInputModel.Bail,
                    CellId = prisonerMailInputModel.CellId,
                    Mails = prisonerMailInputModel.Mails.Select(x => new Mail()
                    {
                        Address = x.Address,
                        Description = x.Description,
                        Sender = x.Sender,
                    }).ToList()
                };

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                prisoners.Add(prisoner);
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            var outputMsg = sb.ToString().TrimEnd();
            return outputMsg;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            const string root = "Officers";
            OfficerPrisonerInputModel[] officerPrisonerInputModels = XmlConverter.Deserializer<OfficerPrisonerInputModel>(xmlString, root);
            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var officerPrisonerInputModel in officerPrisonerInputModels)
            {
                if (IsValid(officerPrisonerInputModel) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Enum.TryParse<Position>(officerPrisonerInputModel.Position, out var position);
                Enum.TryParse<Weapon>(officerPrisonerInputModel.Position, out var weapon);

                var officer = new Officer
                {
                    FullName = officerPrisonerInputModel.Name,
                    Salary = officerPrisonerInputModel.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerPrisonerInputModel.DepartmentId,
                    OfficerPrisoners = officerPrisonerInputModel.Prisoners.Select(x=>new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    }).ToList()
                };

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                officers.Add(officer);
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            var outputMsg = sb.ToString().TrimEnd();
            return outputMsg;
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