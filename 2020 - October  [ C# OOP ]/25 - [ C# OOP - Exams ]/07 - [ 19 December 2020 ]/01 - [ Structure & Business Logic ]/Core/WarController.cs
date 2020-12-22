using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
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
            /* Creates a character and adds them to the party.
			   If the character type is invalid, throw an ArgumentException with the message "Invalid character type "{characterType}"!"
			   Returns the string "{name} joined the party!"
			    */

            string characterType = args[0];
            string name = args[1];

            Character character = characterType switch
            {
                "Warrior" => new Warrior(name),
                "Priest" => new Priest(name),
                _ => null
            };

            var msg = string.Format(Constants.ExceptionMessages.InvalidCharacterType, characterType);
            if (character == null)
            {
                throw new ArgumentException(msg);
            }

            // Add character to party
            this.party.Add(character);

            msg = string.Format(Constants.SuccessMessages.JoinParty, name);
            return msg;
        }

        public string AddItemToPool(string[] args)
        {
            /* Parameters
               •	itemName – string
               Functionality
               Creates an item and adds it to the item pool.
               If the item type is invalid, throw an ArgumentException with the message "Invalid item "{name}"!"
               Returns the string "{itemName} added to pool."
                */

            string itemName = args[0];

            Item item = itemName switch
            {
                "HealthPotion" => new HealthPotion(),
                "FirePotion" => new FirePotion(),
                _ => null
            };

            var msg = string.Format(Constants.ExceptionMessages.InvalidItem, itemName);
            if (item == null)
            {
                throw new ArgumentException(msg);
            }

            this.pool.Add(item);

            msg = string.Format(Constants.SuccessMessages.AddItemToPool, itemName);
            return msg;
        }

        public string PickUpItem(string[] args)
        {
            /* Parameters
               •	characterName – string
               Functionality
               Makes the character with the specified name pick up the last item in the item pool and add it to his/her bag.
               
            If the character doesn’t exist in the party, throw an ArgumentException with the message "Character {name} not found!"
               If there’s no items left in the pool, throw an InvalidOperationException with the message "No items left in pool!"
               Returns the string "{characterName} picked up {itemName}!"
                */

            string characterName = args[0];
            var character = this.party.FirstOrDefault(x => x.Name == characterName);

            var msg = string.Format(Constants.ExceptionMessages.CharacterNotInParty, characterName);
            if (character == null)
            {
                throw new ArgumentException(msg);
            }

            if (this.pool.Count == 0)
            {
                msg = string.Format(Constants.ExceptionMessages.ItemPoolEmpty);
                throw new ArgumentException(msg);
            }

            var item = this.pool.Last();
            character.Bag.AddItem(item);
            this.pool.Remove(item);

            msg = string.Format(Constants.SuccessMessages.PickUpItem, characterName, item.GetType().Name);
            return msg;
        }

        public string UseItem(string[] args)
        {
            /* Parameters
               •	characterName – a string
               •	itemName – string
               Functionality
               Makes the character with that name use an item with that name from their bag.
               If the character doesn’t exist in the party, throw an ArgumentException with the message "Character {name} not found!"
               The rest of the exceptions should be processed by the called functionality (empty bag, etc.)
               Returns the string "{character.Name} used {itemName}."
                */

            string characterName = args[0];
            string itemName = args[1];

            var character = this.party.FirstOrDefault(x => x.Name == characterName);

            var msg = string.Format(Constants.ExceptionMessages.CharacterNotInParty, characterName);
            if (character == null)
            {
                throw new ArgumentException(msg);
            }

            //if (this.pool.Count == 0)
            //{
            //    msg = string.Format(Constants.ExceptionMessages.ItemPoolEmpty);
            //    throw new ArgumentException(msg);
            //}

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            msg = string.Format(Constants.SuccessMessages.UsedItem, characterName, itemName);
            return msg;

        }

        public string GetStats()
        {
            /* Returns info about all characters, sorted by whether they are alive (descending), then by their health (descending)
               The format of a single character is:
               "{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {Alive/Dead}"
               Returns the formatted character info for each character, separated by new lines.
                */

            var sort = this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);

            var sb = new StringBuilder();

            foreach (var character in sort)
            {
                var aliveOrNot = "Dead";
                if (character.IsAlive)
                {
                    aliveOrNot = "Alive";
                }

                var msg = string.Format(Constants.SuccessMessages.CharacterStats,
                    character.Name,
                    character.Health,
                    character.BaseHealth,
                    character.Armor,
                    character.BaseArmor,
                    aliveOrNot);

                sb.AppendLine(msg);
            }

            var finalMsg = sb.ToString().TrimEnd();
            return finalMsg;
        }

        public string Attack(string[] args)
        {
            /* Makes the attacker attack the receiver.
               If any character doesn’t exist in the party, throw an ArgumentException with the message "Character {name} not found!" Check the Attacker first and then the receiver. 
               
               If the attacker cannot attack, throw an ArgumentException with the message "{attacker.Name} cannot attack!"
                */

            string attackerName = args[0];
            string receiverName = args[1];

            var msg = string.Format(Constants.ExceptionMessages.CharacterNotInParty, attackerName);

            var attacker = this.party.FirstOrDefault(x => x.Name == attackerName);
            if (attacker == null)
            {
                throw new ArgumentException(msg);
            }

            var receiver = this.party.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
            {
                msg = string.Format(Constants.ExceptionMessages.CharacterNotInParty, receiverName);
                throw new ArgumentException(msg);
            }

            if (attacker.GetType().Name != nameof(Warrior))
            {
                msg = string.Format(Constants.ExceptionMessages.AttackFail, attackerName);
                throw new ArgumentException(msg);
            }

            var sb = new StringBuilder();
            if (attacker.IsAlive) // TODO: Check this
            {
                receiver.TakeDamage(attacker.AbilityPoints);

                /* The command output is in the following format:
                   "{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiverHealth}/{receiverBaseHealth} HP and {receiverArmor}/{receiverBaseArmor} AP left!"
                   If the attacker ends up killing the receiver, add a new line, plus "{receiver.Name} is dead!" to the output.
                   Returns the formatted string */


                msg = string.Format(Constants.SuccessMessages.AttackCharacter,
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
                    msg = string.Format(Constants.SuccessMessages.AttackKillsCharacter, receiverName);
                    sb.AppendLine(msg);
                }
            }

            var finalMsg = sb.ToString().TrimEnd();
            return finalMsg;
        }

        public string Heal(string[] args)
        {
            /* Parameters
               •	healerName – a string
               •	healingReceiverName – string
               
            Functionality
               Makes the healer heal the healing receiver.
               If any character doesn’t exist in the party, throw an ArgumentException with the message "Character {name} not found!". Check the Healer first and then the receiver. 
               
            If the healer cannot heal, throw an ArgumentException with the message "{healerName} cannot heal!"
               
            
            
                */

            string healerName = args[0];
            string healingReceiverName = args[1];

            var msg = string.Format(Constants.ExceptionMessages.CharacterNotInParty, healerName);

            var healer = this.party.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(msg);
            }

            var receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (receiver == null)
            {
                msg = string.Format(Constants.ExceptionMessages.CharacterNotInParty, healingReceiverName);
                throw new ArgumentException(msg);
            }

            if (healer.GetType().Name != nameof(Priest))
            {
                msg = string.Format(Constants.ExceptionMessages.HealerCannotHeal, healerName);
                throw new ArgumentException(msg);
            }

            var sb = new StringBuilder();
            if (healer.IsAlive) // TODO: Check this
            {
                Priest priest = (Priest) healer;
                priest.Heal(receiver);

                /* "{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!"
                   Returns the formatted string
                    */

                msg = string.Format(Constants.SuccessMessages.HealCharacter,
                    healerName,
                    healingReceiverName,
                    healer.AbilityPoints,
                    healingReceiverName,
                    receiver.Health);

                sb.AppendLine(msg);

                //if (receiver.IsAlive == false)
                //{
                //    msg = string.Format(Constants.SuccessMessages.AttackKillsCharacter, healingReceiverName);
                //    sb.AppendLine(msg);
                //}
            }

            var finalMsg = sb.ToString().TrimEnd();
            return finalMsg;
        }
    }
}
