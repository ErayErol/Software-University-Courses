namespace WarCroft.Entities.Items
{
    using WarCroft.Entities.Characters.Contracts;

    public class HealthPotion : Item
    {
        private const int DEFAULT_WEIGHT = 5;

        public HealthPotion() 
            : base(DEFAULT_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += 20;
        }
    }
}
