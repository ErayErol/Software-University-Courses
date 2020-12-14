namespace OnlineShop.Models.Products.Components
{
    public class VideoCard : Component
    {
        private const double multy = 1.15;

        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * multy, generation)
        {
        }
    }
}
