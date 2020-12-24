namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char SYMBOL = '$';
        private const int POINT = 2;

        public FoodDollar(Wall wall)
            : base(wall, SYMBOL, POINT)
        {
        }
    }
}
