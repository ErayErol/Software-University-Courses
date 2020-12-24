namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char SYMBOL = '\u25A0';

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY - 1);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, SYMBOL);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, SYMBOL);
            }
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 || snake.TopY == this.TopY - 1 || snake.LeftX == this.LeftX - 1;
        }
    }
}
