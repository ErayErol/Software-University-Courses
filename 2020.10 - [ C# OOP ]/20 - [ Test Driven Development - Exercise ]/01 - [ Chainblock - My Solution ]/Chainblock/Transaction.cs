namespace Chainblock
{
    using Contracts;
    using System;

    public class Transaction : ITransaction
    {
        private string @from;
        private string to;
        private decimal amount;

        public Transaction(int id, TransactionStatus status, string @from, string to, decimal amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = @from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id { get; }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get
            {
                return @from;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("From cannot be null or empty.");
                }

                this.@from = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("To cannot be null or empty.");
                }

                this.to = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Amount cannot be negative.");
                }

                this.amount = value;
            }
        }
    }
}
