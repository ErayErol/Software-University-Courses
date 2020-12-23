namespace WarCroft.Entities.Characters
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double DEFAULT_HEALTH = 100;
        private const double DEFAULT_ARMOR = 50;
        private const double DEFAULT_ABILITYPOINTS = 40;

        public Warrior(string name) 
            : base(name, DEFAULT_HEALTH, DEFAULT_ARMOR, DEFAULT_ABILITYPOINTS, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
