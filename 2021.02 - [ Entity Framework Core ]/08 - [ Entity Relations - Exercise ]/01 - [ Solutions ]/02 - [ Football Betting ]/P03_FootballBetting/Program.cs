namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;

    public class Program
    {
        static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}