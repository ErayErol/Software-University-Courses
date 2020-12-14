using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = GetPlayers(players, typeof(Terrorist));
            var counterTerrorists = GetPlayers(players, typeof(CounterTerrorist));

            var result = string.Empty;
            while (true)
            {
                foreach (var t in terrorists.Where(x => x.IsAlive))
                {
                    foreach (var cT in counterTerrorists.Where(x => x.IsAlive))
                    {
                        Attack(cT, t);
                        if (CheckIfAllIsDead(counterTerrorists))
                        {
                            return result = "Terrorist wins!";
                        }

                        Attack(t, cT);
                        if (CheckIfAllIsDead(terrorists))
                        {
                            return result = "Counter Terrorist wins!";
                        }
                    }
                }
            }
        }

        private bool CheckIfAllIsDead(IPlayer[] player)
        {
            return player.All(p => p.IsAlive == false);
        }

        private static void Attack(IPlayer player1, IPlayer player2)
        {
            player1.TakeDamage(player2.Gun.Fire());
        }

        private IPlayer[] GetPlayers(ICollection<IPlayer> players, Type type)
        {
            return players
                .Where(p => p.GetType() == type)
                .ToArray();
        }
    }
}
