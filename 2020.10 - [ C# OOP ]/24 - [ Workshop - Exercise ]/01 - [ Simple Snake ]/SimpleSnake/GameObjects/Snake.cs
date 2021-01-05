namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const char SNAKE_SYMBOL = '\u25CF';
        private const char EMPTY_SPACE = ' ';

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        private Queue<Point> snakeElements;
        private Food[] food;
        private Wall wall;

        public Snake(Wall wall)
        {
            this.wall = wall;
            
            this.snakeElements = new Queue<Point>();
            
            this.food = new Food[3];

            this.foodIndex = RandomFoodNumber;

            GetFoods();
            
            this.CreateSnake();

            this.food[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private int RandomFoodNumber
            => new Random().Next(0, this.food.Length);

        public int Length 
            => this.snakeElements.Count;

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        public bool IsMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            var isPointOfSnake = this.snakeElements.Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SNAKE_SYMBOL);

            if (food[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(EMPTY_SPACE);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = food[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            this.foodIndex = RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void GetFoods()
        {
            this.food[0] = new FoodHash(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodAsterisk(this.wall);
        }
    }
}
