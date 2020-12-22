using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        /* Data
           The Priest class always has 50 Base Health, 25 Base Armor, 40 Ability Points, and a Backpack as a bag.
           Constructor
           The Priest only needs a name for initialization:
           string name
            */

        public Priest(string name) 
            : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            /* For a character to heal another character, both of them need to be alive.
               If this is true, the receiving character’s health increases by the healer’s ability points.
                */

            if (this.IsAlive && character.IsAlive)
            {
                //var item = this.Bag.Items;
                //item.AffectCharacter(character);
                character.Health += this.AbilityPoints;
            }
        }
    }
}
