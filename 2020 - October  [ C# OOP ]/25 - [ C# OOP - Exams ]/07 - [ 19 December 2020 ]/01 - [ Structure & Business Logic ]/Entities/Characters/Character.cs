using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        /* •	Name – a string (cannot be null or whitespace).
           o	Throw an ArgumentException with the message "Name cannot be null or whitespace!"
           •	BaseHealth – a floating-point number – the starting and also the maximum health a character can have
           •	Health – a floating-point number (current health).
           o	Health (current health) should never be more than the BaseHealth or less than 0. 
           •	BaseArmor – a floating-point number – the starting armor a character has
           •	Armor – a floating-point number (current armor)
           o	Armor – the current amount of armor left – can not be less than 0.
           •	AbilityPoints – a floating-point number
           •	Bag – a parameter of type Bag
           •	IsAlive – boolean value (default value: True)

        string name, double health, double armor, double abilityPoints, Bag bag
            */


        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;

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
            set // TODO : private??
            {
                if (value < 0 || value > this.BaseHealth) // TODO: Check this
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
                if (value < 0 || value > this.BaseArmor) // TODO: Check this
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
            /* For a character to take damage, they need to be alive.
               The character takes damage equal to the hit points. Taking damage works like so:
               The character’s armor is reduced by the hit point amount, then if there are still hit points left, they take that amount of health damage.
               If the character’s health drops to zero, the character dies (IsAlive become false)
               Example: Health: 100, Armor: 30, Hit Points: 40  Health: 90, Armor: 0
                */

            if (this.IsAlive)
            {
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
        }

        public void UseItem(Item item)
        {
            /* For a character to use an item, they need to be alive.
               The item affects the character with the item effect.
                */

            if (this.IsAlive)
            {
                item.AffectCharacter(this);
                
            }
        }
    }
}