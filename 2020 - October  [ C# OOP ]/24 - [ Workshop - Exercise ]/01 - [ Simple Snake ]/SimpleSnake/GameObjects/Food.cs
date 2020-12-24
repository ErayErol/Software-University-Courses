namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly Random random;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.FoodPoints = foodPoints;
            this.foodSymbol = foodSymbol;

            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            var isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPartOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(this.LeftX, this.TopY, foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
