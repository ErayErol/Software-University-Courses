using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        /* The Warrior is a special class, who can attack other characters (implements IAttacker).
           Data
           The Warrior class always has 100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel as a bag.
           Constructor
           The Warrior only needs a name for initialization:
           string name
           
        Behavior
           The warrior only has one special behavior (every other behavior is inherited):
           void Attack(Character character)
           For a character to attack another character, both of them need to be alive.
           If the character they are trying to attack is the same character, throw an InvalidOperationException with the message "Cannot attack self!"
           If all of those checks pass, the receiving character takes damage equal to the attacking character’s ability points. The damage is subtracted from the armor points first and once there is no more armor points, from the health points of the receiver.  
            */

        public Warrior(string name) 
            : base(name, 100, 50, 40, new Satchel()) // TODO: Check this
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (character.GetType().Name == this.GetType().Name)
                {
                    throw new InvalidOperationException(Constants.ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
