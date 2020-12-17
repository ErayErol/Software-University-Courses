using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        /* You need to keep track of some things, this is why you need some private fields in your controller class:
           •	guns - GunRepository 
           •	players – PlayerRepository
           •	map - IMap
            */
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly Map map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }


        /*Adds a Gun and adds it to the GunRepository. Valid types are: "Pistol" and "Rifle".
           If the Gun type is invalid, you have to throw an ArgumentException with the following message:
           •	"Invalid gun type."
           If the Gun is added successfully, the method should return the following string:
           •	"Successfully added gun {gunName}."
           */

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = type switch
            {
                "Pistol" => new Pistol(name, bulletsCount),
                "Rifle" => new Rifle(name, bulletsCount),
                _ => null
            };

            if (gun == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);
            var outputMessage = string.Format(OutputMessages.SuccessfullyAddedGun, name);
            return outputMessage;
        }


        /* Creates a Player of the given type and adds it to the PlayerRepository. Valid types are: "Terrorist" and "CounterTerrorist". 
           If the gun is not found throw ArgumentException with message:
           •	"Gun cannot be found!"
           If the player type is invalid, throw an ArgumentException with message:
           •	"Invalid player type!"
           The method should return the following string if the operation is successful:
           •	"Successfully added player {playerUsername}."
            */

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = type switch
            {
                "Terrorist" => new Terrorist(username, health, armor, gun),
                "CounterTerrorist" => new CounterTerrorist(username, health, armor, gun),
                _ => null
            };

            if (player == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);
            var outputMessage = string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
            return outputMessage;
        }

        /*Game starts with all players that are alive! Returns the result from the Start() method.*/

        public string StartGame()
        {
            return this.map.Start((ICollection<IPlayer>) this.players.Models);
        }

        /* Returns information about each player separated with a new line. Order them by type alphabetically, then by health descending, then by username alphabetically. You can use the overridden ToString Player method.
           "{player type}: {player username}");
           "--Health: {player health}");
           "--Armor: {player armor}");
           "--Gun: {player gun name}")
           Note: Use \r\n or Environment.NewLine for a new line and don't forget to trim the end if you use StringBuilder.
            */

        public string Report()
        {
            var sortedPlayers = this.players.Models
                .OrderBy(x=>x.GetType().Name)
                .ThenByDescending(x=>x.Health)
                .ThenBy(x => x.Username);

            var sb = new StringBuilder();
            foreach (var player in sortedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
