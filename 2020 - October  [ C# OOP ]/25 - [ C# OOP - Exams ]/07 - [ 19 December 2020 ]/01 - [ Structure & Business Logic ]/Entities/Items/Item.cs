using System;

using WarCroft.Entities.Characters.Contracts;
using WarCroft.Constants;

namespace WarCroft.Entities.Items
{
	// Christmas came early this year - this class is already implemented for you!
	public abstract class Item
	{
		/* This is a base class for any items and it should not be able to be instantiated. 
		   This class is already implemented for you in the skeleton! All that is left for you is to implement the FirePotion and HealthPotion child classes.
		    */

		protected Item(int weight)
		{
			this.Weight = weight;
		}

		public int Weight { get; private set; }

		public virtual void AffectCharacter(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}
