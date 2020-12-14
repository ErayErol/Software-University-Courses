namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        private const double multy = 1.05;

        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance * multy, generation)
        {
        }
    }
}
