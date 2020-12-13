namespace Chainblock.Contracts
{
    public interface ITransaction
    {
        int Id { get; }

        TransactionStatus Status { get; set; }

        string From { get; }

        string To { get; }

        decimal Amount { get; }
    }
}