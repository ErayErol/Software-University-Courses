namespace WarCroft.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Items;

    public class WarController
    {
        private List<Character> party;
        private List<Item> pool;

        public WarController()
        {
            this.party = new List<Character>();
            this.pool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            var msg = string.Format(ExceptionMessages.InvalidCharacterType, characterType);
            Character character = characterType switch
            {
                nameof(Warrior) => new Warrior(name),
                nameof(Priest) => new Priest(name),
                _ => throw new ArgumentException(msg)
            };

            this.party.Add(character);

            msg = string.Format(SuccessMessages.JoinParty, name);
            return msg;
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            var msg = string.Format(ExceptionMessages.InvalidItem, itemName);
            Item item = itemName switch
            {
                nameof(HealthPotion) => new HealthPotion(),
                nameof(FirePotion) => new FirePotion(),
                _ => throw new ArgumentException(msg)
            };

            this.pool.Add(item);

            msg = string.Format(SuccessMessages.AddItemToPool, itemName);
            return msg;
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var character = this.party.FirstOrDefault(x => x.Name == characterName);

            var msg = string.Format(ExceptionMessages.CharacterNotInParty, characterName);
            if (character == null)
            {
                throw new ArgumentException(msg);
            }

            if (this.pool.Count == 0)
            {
                msg = string.Format(ExceptionMessages.ItemPoolEmpty);
                throw new ArgumentException(msg);
            }

            var item = this.pool.Last();
            character.Bag.AddItem(item);
            this.pool.Remove(item);

            msg = string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
            return msg;
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = this.party.FirstOrDefault(x => x.Name == characterName);

            var msg = string.Format(ExceptionMessages.CharacterNotInParty, characterName);
            if (character == null)
            {
                throw new ArgumentException(msg);
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            msg = string.Format(SuccessMessages.UsedItem, characterName, itemName);
            return msg;

        }

        public string GetStats()
        {
            var characters = this.party
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health);

            //var characters =
            //    from character in this.party
            //    orderby character.IsAlive descending, character.Health descending
            //    select character;

            StringBuilder sb = new StringBuilder();
            foreach (var character in characters)
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var msg = string.Format(ExceptionMessages.CharacterNotInParty, attackerName);

            var attacker = this.party.FirstOrDefault(x => x.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException(msg);
            }

            var receiver = this.party.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
            {
                msg = string.Format(ExceptionMessages.CharacterNotInParty, receiverName);
                throw new ArgumentException(msg);
            }

            if (attacker.GetType().Name != nameof(Warrior))
            {
                msg = string.Format(ExceptionMessages.AttackFail, attackerName);
                throw new ArgumentException(msg);
            }

            var sb = new StringBuilder();
            if (attacker.IsAlive)
            {
                Warrior warrior = (Warrior)attacker;
                warrior.Attack(receiver);

                msg = string.Format(SuccessMessages.AttackCharacter,
                    attackerName,
                    receiverName,
                    attacker.AbilityPoints,
                    receiverName,
                    receiver.Health,
                    receiver.BaseHealth,
                    receiver.Armor,
                    receiver.BaseArmor);

                sb.AppendLine(msg);

                if (receiver.IsAlive == false)
                {
                    msg = string.Format(SuccessMessages.AttackKillsCharacter, receiverName);
                    sb.AppendLine(msg);
                }
            }

            var finalMsg = sb.ToString().TrimEnd();
            return finalMsg;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var msg = string.Format(ExceptionMessages.CharacterNotInParty, healerName);

            var healer = this.party.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(msg);
            }

            var receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (receiver == null)
            {
                msg = string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName);
                throw new ArgumentException(msg);
            }

            if (healer.GetType().Name != nameof(Priest))
            {
                msg = string.Format(ExceptionMessages.HealerCannotHeal, healerName);
                throw new ArgumentException(msg);
            }

            var sb = new StringBuilder();
            if (healer.IsAlive)
            {
                Priest priest = (Priest)healer;
                priest.Heal(receiver);

                msg = string.Format(SuccessMessages.HealCharacter,
                    healerName,
                    healingReceiverName,
                    healer.AbilityPoints,
                    healingReceiverName,
                    receiver.Health);

                sb.AppendLine(msg);
            }

            var finalMsg = sb.ToString().TrimEnd();
            return finalMsg;
        }
    }
}
