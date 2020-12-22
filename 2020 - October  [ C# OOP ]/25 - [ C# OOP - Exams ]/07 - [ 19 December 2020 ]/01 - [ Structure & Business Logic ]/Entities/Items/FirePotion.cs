using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        /* The Fire potion is a type of item. It always has a weight of 5.
           Behavior
           Each FirePotion has the following behavior:

           void AffectCharacter(Character character)
           For an item to affect a character, the character needs to be alive.
           The character’s health gets decreased by 20 points. If the character’s health drops to zero, the character dies (IsAlive  false).

        A FirePotion should be able to be instantiated without any parameters.
            */

        private const int DEFAULT_WEIGHT = 5;

        public FirePotion()
            : base(DEFAULT_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            // TODO: The character’s health gets decreased by 20 points.If the character’s health drops to zero, the character dies(IsAlive  false).

            character.Health -= 20;
        }
    }
}
