using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerName);
                }
                username = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerHealth);
                }
                health = value;
            }
        }

        public int Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerArmor);
                }
                armor = value;
            }
        }

        public IGun Gun
        {
            get => gun;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidGun);
                }
                gun = value;
            }
        }

        public bool IsAlive
            => this.Health > 0;

        public void TakeDamage(int points)
        {
            if (this.Armor > points)
            {
                this.Armor -= points;
                return;
            }

            points -= this.Armor;
            this.Armor = 0;

            if (this.Health > points)
            {
                this.Health -= points;
                return;
            }

            this.Health = 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
