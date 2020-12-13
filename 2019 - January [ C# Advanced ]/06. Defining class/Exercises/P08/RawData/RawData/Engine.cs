namespace RawData
{
    public class Engine
    {
        private int power;
        private int speed;

        public Engine(int power, int speed)
        {
            this.Power = power;
            this.Speed = speed;
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
    }
}