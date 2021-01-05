namespace WarCroft.Entities.Items
{
    using WarCroft.Entities.Characters.Contracts;

    public class FirePotion : Item
    {
        private const int DEFAULT_WEIGHT = 5;

        public FirePotion()
            : base(DEFAULT_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            if (character.Health > 20)
            {
                character.Health -= 20;
            }
            else
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}