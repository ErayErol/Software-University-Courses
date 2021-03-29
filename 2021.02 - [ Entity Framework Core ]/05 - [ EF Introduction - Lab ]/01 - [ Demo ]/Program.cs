namespace Demo
{
    using Demo.Data;
    using Microsoft.EntityFrameworkCore;

    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.Migrate();
        }
    }
}
