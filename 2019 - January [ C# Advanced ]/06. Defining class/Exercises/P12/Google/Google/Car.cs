namespace Google
{
    public class Car
    {
        private string carModel;
        private string carSpeed;

        public Car()
        {

        }
        public Car(string carModel, string carSpeed)
        {
            this.CarModel = carModel;
            this.CarSpeed = carSpeed;
        }

        public override string ToString()
        {
            if (carModel == null)
            {
                return "";
            }
            return "\r\n" + this.CarModel + " " + this.CarSpeed;
        }

        public string CarModel { get => carModel; set => carModel = value; }
        public string CarSpeed { get => carSpeed; set => carSpeed = value; }
    }
}