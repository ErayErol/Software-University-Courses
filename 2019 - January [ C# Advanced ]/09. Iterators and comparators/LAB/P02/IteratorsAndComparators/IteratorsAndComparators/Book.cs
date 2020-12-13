namespace IteratorsAndComparators
{
    using System.Collections.Generic;
    using System.Text;

    public class Book
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors { get; private set; }

        //public override string ToString()
        //{
        //    var sb = new StringBuilder();
        //    sb.AppendLine($"{this.Title} - {this.Year} - {string.Join(", ", this.Authors)}");

        //    var result = sb.ToString().TrimEnd();
        //    return result;
        //}
    }
}