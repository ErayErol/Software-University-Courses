namespace OnlineShop.Models.Products.Components
{

    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation { get; private set; }

        public override string ToString()
        {
            string result = string.Format(Common.Constants.SuccessMessages.ComponentToString, this.Generation);
            return base.ToString() + result;
        }
    }
}
