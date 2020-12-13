namespace CarSalesman
{

    public class Engine
    {
        private string model;
        private int power;
        private string displacement;
        private string efficiency;

        public Engine()
        {
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public Engine(string model)
            : this()
        {
            this.Model = model;
        }

        public Engine(string model, int power)
            : this(model)
        {
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }

        public string Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}