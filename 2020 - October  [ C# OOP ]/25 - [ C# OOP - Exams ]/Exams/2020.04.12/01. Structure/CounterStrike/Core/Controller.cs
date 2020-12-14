namespace CounterStrike.Core
{
    using CounterStrike.Core.Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Maps;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories;
    using CounterStrike.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<IGun> guns;
        private IRepository<IPlayer> players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);

            string result = string.Format(Utilities.Messages.OutputMessages.SuccessfullyAddedGun, name);
            return result;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;
            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);

            string result = string.Format(Utilities.Messages.OutputMessages.SuccessfullyAddedPlayer, username);
            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var sortedPlayers = this.players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username);

            foreach (var player in sortedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var players = this.players.Models;
            return this.map.Start((ICollection<IPlayer>)players);
        }
    }
}
