namespace BookShop.DataProcessor
{
    using Data;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using BookShop.Utilities;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} {1} with {2} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var books = XmlConverter.Deserializer<BookXML>(xmlString, "Books");
            var sb = new StringBuilder();

            foreach (var bookXml in books)
            {
                var isValidDate = DateTime
                    .TryParseExact(bookXml.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var publishedOn);

                if (IsValid(bookXml) == false || isValidDate == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = bookXml.Name,
                    Price = bookXml.Price,
                    Genre = (Genre)bookXml.Genre,
                    Pages = bookXml.Pages,
                    PublishedOn = publishedOn,
                };

                context.Books.Add(book);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authors = JsonConvert.DeserializeObject<AuthorJSON[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var authorJson in authors)
            {
                var email = context.Authors
                    .FirstOrDefault(x => x.Email == authorJson.Email);

                if (IsValid(authorJson) == false || authorJson.Books.Length == 0 || email != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author()
                {
                    FirstName = authorJson.FirstName,
                    LastName = authorJson.LastName,
                    Phone = authorJson.Phone,
                    Email = authorJson.Email,
                };

                foreach (var bookJson in authorJson.Books)
                {
                    if (bookJson.Id.HasValue)
                    {
                        var book = context.Books.FirstOrDefault(x => x.Id == bookJson.Id.Value);
                        if (book != null)
                        {
                            author.AuthorsBooks.Add(new AuthorBook() { Book = book });
                        }
                    }
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Authors.Add(author);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName, author.LastName, author.AuthorsBooks.Count));
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