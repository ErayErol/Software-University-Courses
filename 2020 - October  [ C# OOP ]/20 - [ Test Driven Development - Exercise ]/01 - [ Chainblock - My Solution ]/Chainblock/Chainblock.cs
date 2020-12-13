namespace Chainblock
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Chainblock : IChainblock
    {
        private readonly HashSet<int> txIds;
        private readonly List<ITransaction> txsByIndex;
        private readonly Dictionary<int, ITransaction> txsById;
        private readonly SortedDictionary<TransactionStatus, IList<ITransaction>> txsByStatus;

        public Chainblock()
        {
            this.txIds = new HashSet<int>();
            this.txsByIndex = new List<ITransaction>();
            this.txsById = new Dictionary<int, ITransaction>();
            this.txsByStatus = new SortedDictionary<TransactionStatus, IList<ITransaction>>();
        }

        public void Add(ITransaction tx)
        {
            this.ValidateNullTx(tx);

            if (this.Contains(tx.Id))
            {
                throw new ArgumentException($"A transaction with {tx.Id} Id already exist.");
            }

            this.InitializeCollection(tx);

            this.txIds.Add(tx.Id);
            this.txsByIndex.Add(tx);
            this.txsById[tx.Id] = tx;
            this.txsByStatus[tx.Status].Add(tx);

        }

        private void InitializeCollection(ITransaction tx)
        {
            if (this.txsByStatus.ContainsKey(tx.Status) == false)
            {
                this.txsByStatus[tx.Status] = new List<ITransaction>();
            }
        }

        public int Count
        {
            get
            {
                return this.txsByIndex.Count;
            }
        }

        public bool Contains(ITransaction tx)
        {
            this.ValidateNullTx(tx);

            return this.txIds.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            return this.txIds.Contains(id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (this.txsById.ContainsKey(id) == false)
            {
                throw new ArgumentException($"Transaction with {id} id does not exist.");
            }

            ITransaction tx = this.txsById[id];
            tx.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            if (this.txsById.ContainsKey(id) == false)
            {
                throw new InvalidOperationException($"Transaction with {id} id does not exist.");
            }

            ITransaction tx = this.GetById(id);
            this.RemoveProductFromCollections(tx);

            this.txsByIndex.RemoveAll(t => t.Id == id);
            this.txsById.Remove(id);
            this.txIds.Remove(id);
        }

        private void RemoveProductFromCollections(ITransaction tx)
        {
            var allWithTransactionStatus = this.txsByStatus[tx.Status].ToList();
            allWithTransactionStatus.RemoveAll(t => t.Id == tx.Id);

        }

        public ITransaction GetById(int id)
        {
            if (this.txsById.ContainsKey(id) == false)
            {
                throw new InvalidOperationException($"Transaction with {id} id does not exist.");
            }

            return this.txsById[id];
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (this.txsByStatus.ContainsKey(status) == false)
            {
                throw new InvalidOperationException($"Transaction with {status} status does not exist.");
            }

            return this.txsByStatus[status]
                .OrderByDescending(t => t.Amount).ToList().AsEnumerable();

        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (this.txsByStatus.ContainsKey(status) == false)
            {
                throw new InvalidOperationException($"Transaction with {status} status does not exist.");
            }

            return this.GetByTransactionStatus(status)
                .Select(t => t.From).ToList().AsEnumerable();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (this.txsByStatus.ContainsKey(status) == false)
            {
                throw new InvalidOperationException($"Transaction with {status} status does not exist.");
            }

            return this.GetByTransactionStatus(status)
                .Select(t => t.To).ToList().AsEnumerable();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            if (this.txIds.Any() == false)
            {
                throw new ArgumentException("There are no transactions.");
            }

            return this.txsByIndex
                .OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (this.txsByIndex.Any(t => t.From == sender) == false)
            {
                throw new InvalidOperationException($"Transaction with {sender} sender does not exist.");
            }

            return this.txsByIndex
                .Where(t => t.From == sender).OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (this.txsByIndex.Any(t => t.To == receiver) == false)
            {
                throw new InvalidOperationException($"Transaction with {receiver} receiver does not exist.");
            }

            return this.txsByIndex
                .Where(t => t.To == receiver).OrderByDescending(t => t.Amount).OrderBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, decimal amount)
        {
            if (this.txsByStatus.ContainsKey(status) == false)
            {
                return Enumerable.Empty<ITransaction>();
            }

            return this.txsByStatus[status]
                .OrderByDescending(t => t.Amount).Where(t => t.Amount <= amount).ToList().AsEnumerable();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, decimal amount)
        {
            if (this.txsByIndex.Any(t => t.From == sender) == false)
            {
                throw new InvalidOperationException($"Transaction with {sender} sender does not exist.");
            }

            return this.txsByIndex
                .Where(t => t.From == sender).Where(t => t.Amount > amount).OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, decimal lo, decimal hi)
        {
            if (this.txsByIndex.Any(t => t.To == receiver) == false)
            {
                throw new InvalidOperationException($"Transaction with {receiver} receiver does not exist.");
            }

            return this.txsByIndex
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .OrderBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(decimal lo, decimal hi)
        {
            if (this.txIds.Any() == false)
            {
                return Enumerable.Empty<ITransaction>();
            }

            return this.txsByIndex
                .Where(t => t.Amount >= lo && t.Amount < hi);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.txsByIndex.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateNullTx(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException("Transaction cannot be null.");
            }
        }
    }
}
