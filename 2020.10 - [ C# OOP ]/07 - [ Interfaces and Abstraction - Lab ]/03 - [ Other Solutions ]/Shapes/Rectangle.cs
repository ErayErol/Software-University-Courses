namespace Shapes
{
    using System;

    public class Rectangle : IDrawable
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height can not be zero or negative!");
                }

                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width can not be zero or negative!");
                }

                this.width = value;
            }
        }

        public void Draw()
        {
            Console.WriteLine(new string('*', this.Width));

            for (int i = 0; i < this.Height - 2; i++)
            {
                Console.WriteLine("*" + new string(' ', this.Width - 2) + "*");
            }

            Console.WriteLine(new string('*', Width));
        }
    }
}