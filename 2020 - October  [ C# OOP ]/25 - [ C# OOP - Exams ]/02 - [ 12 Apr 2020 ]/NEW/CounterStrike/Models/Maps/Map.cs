using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(p => p.GetType() == typeof(Terrorist)).ToList();
            var counterTerrorists = players.Where(p => p.GetType() == typeof(CounterTerrorist)).ToList();

            while (true)
            {
                foreach (IPlayer aliveTerrorist in terrorists.Where(p => p.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists)
                    {
                        counterTerrorist.TakeDamage(aliveTerrorist.Gun.Fire());
                    }
                }

                if (counterTerrorists.All(p => p.IsAlive == false))
                {
                    return "Terrorist wins!";
                }

                foreach (IPlayer aliveCounterTerrorist in counterTerrorists.Where(p => p.IsAlive))
                {
                    foreach (var terrorist in terrorists)
                    {
                        terrorist.TakeDamage(aliveCounterTerrorist.Gun.Fire());
                    }
                }

                if (terrorists.All(p => p.IsAlive == false))
                {
                    return "Counter Terrorist wins!";
                }
            }
        }
    }
}
