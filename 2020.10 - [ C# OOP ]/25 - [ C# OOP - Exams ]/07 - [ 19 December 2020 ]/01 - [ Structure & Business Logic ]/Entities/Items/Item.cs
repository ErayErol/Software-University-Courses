namespace WarCroft.Entities.Items
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;

    public abstract class Item
	{
        protected Item(int weight)
		{
			this.Weight = weight;
		}

		public int Weight { get; }

		public virtual void AffectCharacter(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}
