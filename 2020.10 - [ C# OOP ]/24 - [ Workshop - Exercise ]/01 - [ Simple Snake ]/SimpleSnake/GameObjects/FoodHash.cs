namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char SYMBOL = '#';
        private const int POINT = 3;

        public FoodHash(Wall wall)
            : base(wall, SYMBOL, POINT)
        {
        }
    }
}
