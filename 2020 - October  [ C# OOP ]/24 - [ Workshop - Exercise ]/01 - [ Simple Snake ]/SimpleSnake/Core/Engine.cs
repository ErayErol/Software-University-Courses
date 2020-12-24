using System.Text;

namespace SimpleSnake.Core
{
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
    using System;
    using System.Threading;

    public class Engine
    {
        private Wall wall;
        private Snake snake;
        private double sleepTime;
        private Point[] poIntsOfDirection;
        private Direction direction;
        private bool isCorrectKey;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            this.poIntsOfDirection = new Point[4];
            this.direction = Direction.Right;
            this.isCorrectKey = false;
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(this.poIntsOfDirection[(int)direction]);

                if (isMoving == false)
                {
                    AskUserForRestart();
                }

                this.sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void CreateDirections()
        {
            this.poIntsOfDirection[0] = new Point(1, 0);
            this.poIntsOfDirection[1] = new Point(-1, 0);
            this.poIntsOfDirection[2] = new Point(0, 1);
            this.poIntsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            else
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                Console.SetCursorPosition(left, top);
                Console.Write(" ");
            }

            Console.CursorVisible = false;

            bool isMoving = this.snake.IsMoving(this.poIntsOfDirection[(int)direction]);

            if (isMoving == false)
            {
                AskUserForRestart();
            }
        }

        private void AskUserForRestart()
        {
            Console.SetCursorPosition(0, this.wall.TopY + 2);

            var sb = new StringBuilder();
            sb.AppendLine($"Your score: {snake.Length}");
            sb.AppendLine("Press [R] to Restart.");
            sb.AppendLine("Press [N] to stop the game.");
            Console.WriteLine(sb.ToString());

            while (true)
            {
                Console.SetCursorPosition(0, this.wall.TopY + 6);
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    StartUp.Main();
                }
                else if (userInput.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(0, this.wall.TopY + 6);
                    Console.Write(" ");
                    Console.SetCursorPosition(0, this.wall.TopY + 6);
                    Console.WriteLine("Game over!");
                    Environment.Exit(0);
                }

                Console.SetCursorPosition(0, this.wall.TopY + 6);
                Console.Write(" ");
            }
        }
    }
}
