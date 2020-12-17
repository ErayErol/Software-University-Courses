using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models
            => this.players.ToList().AsReadOnly();

        public void Add(IPlayer model)
        {
            // TODO: Check this
            if (model == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerRepository);
            }

            this.players.Add(model);
        }

        public bool Remove(IPlayer model)
            => this.players.Remove(model);

        public IPlayer FindByName(string name)
            => this.players.FirstOrDefault(x => x.Username == name);
    }
}
