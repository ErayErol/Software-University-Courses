using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly IList<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
            => (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerRepository);
            }

            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
            => this.players.FirstOrDefault(g => g.Username == name);

        public bool Remove(IPlayer model)
        {
            var player = this.players.FirstOrDefault(g => g.Username == model.Username);

            if (player == null)
            {
                return false;
            }

            this.players.Remove(player);
            return true;
        }
    }
}
