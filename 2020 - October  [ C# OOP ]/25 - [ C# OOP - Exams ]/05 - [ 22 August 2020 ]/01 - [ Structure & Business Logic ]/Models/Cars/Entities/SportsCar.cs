namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int CUBIC_POWER = 3000;
        private const int MIN_HORSE_POWER = 250;
        private const int MAX_HORSE_POWER = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CUBIC_POWER, MIN_HORSE_POWER, MAX_HORSE_POWER)
        {
        }
    }
}
