namespace Bakery.Models.Drinks
{
    public class Water : Drink
    {
        public Water(string name, int portion, string brand) 
            : base(name, portion, 1.5M, brand)
        {
        }
    }
}
