using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        /* The health potion is a type of item. It always has a weight of 5.
        
        Behavior
           
        Each HealthPotion has the following behavior:
        
        void AffectCharacter(Character character)
        
        For an item to affect a character, the character needs to be alive.
           The character’s health gets increased by 20 points.
           Constructor
           An item should be able to be instantiated without any parameters.
            */
        private const int DEFAULT_WEIGHT = 5;

        public HealthPotion() 
            : base(DEFAULT_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            // TODO: The character’s health gets increased by 20 points.
            character.Health += 20;
        }
    }
}
