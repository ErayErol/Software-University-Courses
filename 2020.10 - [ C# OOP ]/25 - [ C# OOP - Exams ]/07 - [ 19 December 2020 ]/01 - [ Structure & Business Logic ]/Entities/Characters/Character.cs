namespace WarCroft.Entities.Characters.Contracts
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;
    using WarCroft.Entities.Items;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

            this.BaseHealth = Health;
            this.BaseArmor = Armor;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Constants.ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => health;
            set
            {
                if (value < 0 || value > this.BaseHealth)
                {
                    health = this.BaseHealth;
                }
                health = value;
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0 || value > this.BaseArmor)
                {
                    armor = this.BaseArmor;
                }
                armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor > hitPoints)
            {
                this.Armor -= hitPoints;
                return;
            }

            hitPoints -= this.Armor;
            this.Armor = 0;

            if (this.Health > hitPoints)
            {
                this.Health -= hitPoints;
                return;
            }

            this.IsAlive = false;
            this.Health = 0;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            string isAliveOrDead = this.IsAlive
                ? "Alive"
                : "Dead";

            var format = string.Format(SuccessMessages.CharacterStats,
                this.Name,
                this.Health,
                this.BaseHealth,
                this.Armor,
                this.BaseArmor,
                isAliveOrDead);

            return format;
        }
    }
}