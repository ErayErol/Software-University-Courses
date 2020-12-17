namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        public Tea(string name, int portion, string brand) 
            : base(name, portion, 2.5M, brand)
        {
        }
    }
}
