namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char SYMBOL = '*';
        private const int POINT = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, SYMBOL, POINT)
        {
        }
    }
}
