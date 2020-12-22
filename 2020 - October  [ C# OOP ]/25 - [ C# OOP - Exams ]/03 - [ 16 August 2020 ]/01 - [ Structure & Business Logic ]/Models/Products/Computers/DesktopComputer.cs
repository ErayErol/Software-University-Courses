namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        private const int DEFAULT_OVERALLPERFORMANCE = 15;

        public DesktopComputer(int id, string manufacturer, string model, decimal price) 
            : base(id, manufacturer, model, price, DEFAULT_OVERALLPERFORMANCE)
        {
        }
    }
}
