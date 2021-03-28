namespace Code_First
{
    using Code_First.Models;

    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            // If you want, you can add News, Category, Comment to Database 

            //db.Categories.Add(new Category
            //{
            //    Title = "Sport"
            //});

            // After adding C# Classes to Database then call method db.SaveChanges(); to save current changes to Database

            //db.SaveChanges();
        }
    }
}
