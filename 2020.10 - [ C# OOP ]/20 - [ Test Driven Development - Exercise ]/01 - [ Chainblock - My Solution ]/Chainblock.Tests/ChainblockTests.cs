namespace Chainblock.Tests
{
    using Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ChainblockTests
    {
        private const int Id = 10;
        private const TransactionStatus TransactionStatus = global::Chainblock.TransactionStatus.Successful;
        private const string From = "The sender";
        private const string To = "The receiver";
        private const decimal Amount = 8000;

        private const int AnotherId = 20;
        private const TransactionStatus AnotherTransactionStatus = global::Chainblock.TransactionStatus.Failed;
        private const string AnotherFrom = "Another sender";
        private const string AnotherTo = "Another receiver";
        private const decimal AnotherAmount = 12000;

        private Chainblock chainblock;
        private Transaction tx;
        private Transaction anotherTx;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
            this.tx = new Transaction(Id, TransactionStatus, From, To, Amount);
            this.anotherTx = new Transaction(AnotherId, AnotherTransactionStatus, AnotherFrom, AnotherTo, AnotherAmount);
        }

        [Test]
        public void AddMethod_WhenAddTransaction_ThenTransactionShouldBeAddCorrectly()
        {
            this.chainblock.Add(this.tx);

            Mock<ITransaction> fakeTx = new Mock<ITransaction>();
            fakeTx.Setup(t => t.Id).Returns(Id);
            fakeTx.Setup(t => t.Status).Returns(TransactionStatus);
            fakeTx.Setup(t => t.From).Returns(From);
            fakeTx.Setup(t => t.To).Returns(To);
            fakeTx.Setup(t => t.Amount).Returns(Amount);

            Assert.That(fakeTx.Object.Id, Is.EqualTo(Id));
            Assert.That(fakeTx.Object.Status, Is.EqualTo(TransactionStatus));
            Assert.That(fakeTx.Object.From, Is.EqualTo(From));
            Assert.That(fakeTx.Object.To, Is.EqualTo(To));
            Assert.That(fakeTx.Object.Amount, Is.EqualTo(Amount));
        }

        [Test]
        public void AddMethod_WhenAddTransactionWithExistId_ThenThrowException()
        {
            this.chainblock.Add(this.tx);

            Assert.Throws<ArgumentException>(() =>
                    this.chainblock.Add(this.tx)
                , $"A transaction with {tx.Id} Id already exist.");
        }

        [Test]
        public void AddMethod_WhenAddNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                    this.chainblock.Add(null)
                , "Transaction cannot be null.");
        }

        [Test]
        public void Count_WhenAddTwoTransaction_ThenCountShouldReturnTwo()
        {
            this.chainblock.Add(this.tx);
            this.chainblock.Add(this.anotherTx);

            int expectedCount = chainblock.Count;
            int actualCount = 2;

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void Contains_WhenTransactionExist_ThenShouldReturnTrue()
        {
            this.chainblock.Add(this.tx);
            this.chainblock.Add(this.anotherTx);

            bool expectedBoolen = chainblock.Contains(this.anotherTx);
            bool actualBoolen = true;

            Assert.That(expectedBoolen, Is.EqualTo(actualBoolen));
        }

        [Test]
        public void Contains_WhenTransactionDoesNotExist_ThenShouldReturnFalse()
        {
            bool expectedBoolen = chainblock.Contains(this.anotherTx);
            bool actualBoolen = false;

            Assert.That(expectedBoolen, Is.EqualTo(actualBoolen));
        }

        [Test]
        [TestCase(5)]
        public void ChangeTransactionStatusMethod_WhenTransactionWithGivenIdDoesNotExist_ThenShouldThrowException(int id)
        {
            Assert.Throws<ArgumentException>(() =>
                    this.chainblock.ChangeTransactionStatus(id, AnotherTransactionStatus)
                , $"Transaction with {id} id does not exist.");
        }

        [Test]
        public void ChangeTransactionStatusMethod_WhenTransactionWithGivenIdExist_ThenShouldChangeStatus()
        {
            this.chainblock.Add(this.tx);
            this.chainblock.Add(this.anotherTx);

            this.chainblock.ChangeTransactionStatus(this.tx.Id, this.anotherTx.Status);

            var expectedStatus = this.tx.Status;
            var actualStatus = AnotherTransactionStatus;

            Assert.That(expectedStatus, Is.EqualTo(actualStatus));
        }

        [Test]
        [TestCase(5)]
        public void RemoveTransactionByIdMethod_WhenTransactionWithGivenIdDoesNotExist_ThenShouldThrowException(int id)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.RemoveTransactionById(id)
                , $"Transaction with {id} id does not exist.");
        }

        [Test]
        public void RemoveTransactionByIdMethod_WhenTransactionWithGivenIdExist_ThenShouldRemoveTransaction()
        {
            this.chainblock.Add(this.tx);
            this.chainblock.Add(this.anotherTx);

            this.chainblock.RemoveTransactionById(this.tx.Id);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(this.tx), Is.EqualTo(false));
        }

        [Test]
        [TestCase(5)]
        public void GetByIdMethod_WhenTransactionWithGivenIdDoesNotExist_ThenShouldThrowException(int id)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetById(id)
                , $"Transaction with {id} id does not exist.");
        }

        [Test]
        public void GetByIdMethod_WhenTransactionWithGivenIdExist_ThenShouldReturnGivenTransaction()
        {
            this.chainblock.Add(this.tx);
            this.chainblock.Add(this.anotherTx);

            ITransaction txInChainblock = this.chainblock.GetById(this.tx.Id);

            Assert.That(txInChainblock.Id, Is.EqualTo(Id));
            Assert.That(txInChainblock.Status, Is.EqualTo(TransactionStatus));
            Assert.That(txInChainblock.From, Is.EqualTo(From));
            Assert.That(txInChainblock.To, Is.EqualTo(To));
            Assert.That(txInChainblock.Amount, Is.EqualTo(Amount));
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetByTransactionStatusMethod_WhenTransactionWithGivenStatusDoesNotExist_ThenShouldThrowException(TransactionStatus status)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetByTransactionStatus(status)
                , $"Transaction with {status} status does not exist.");
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetByTransactionStatusMethod_WhenTransactionWithGivenStatusExist_ThenShouldReturnCorrectResult(TransactionStatus status)
        {
            this.AddMultipleTransactionsToChainblock();

            var expected = this.chainblock.GetByTransactionStatus(status);

            var actual = this.chainblock
                .Where(t => t.Status == status).OrderByDescending(t => t.Amount);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetAllSendersWithTransactionStatusMethod_WhenTransactionWithGivenStatusDoesNotExist_ThenShouldThrowException(TransactionStatus status)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetAllSendersWithTransactionStatus(status)
                , $"Transaction with {status} status does not exist.");
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetAllSendersWithTransactionStatusMethod_WhenTransactionWithGivenStatusExist_ThenShouldReturnCorrectResult(TransactionStatus status)
        {
            this.AddMultipleTransactionsToChainblock();

            this.chainblock
                .Add(new Transaction(1010, status, "Sender1000", "Receiver1000", 1000));

            var expected = this.chainblock.GetAllSendersWithTransactionStatus(status);

            var actual = this.chainblock
                .Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.From).ToList();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetAllReceiversWithTransactionStatusMethod_WhenTransactionWithGivenStatusDoesNotExist_ThenShouldThrowException(TransactionStatus status)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetAllReceiversWithTransactionStatus(status)
                , $"Transaction with {status} status does not exist.");
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized)]
        public void GetAllReceiversWithTransactionStatusMethod_WhenTransactionWithGivenStatusExist_ThenShouldReturnCorrectResult(TransactionStatus status)
        {
            this.AddMultipleTransactionsToChainblock();

            this.chainblock
                .Add(new Transaction(1010, status, "Sender1000", "Receiver1000", 1000));

            var expected = this.chainblock.GetAllReceiversWithTransactionStatus(status);

            var actual = this.chainblock
                .Where(t => t.Status == status).OrderByDescending(t => t.Amount).Select(t => t.To).ToList();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethod_WhenThereAreNoTransactions_ThenShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
                    this.chainblock.GetAllOrderedByAmountDescendingThenById()
                , "There are no transactions.");
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethod_WhenThereAreTransactions_ThenShouldReturnCorrectResult()
        {
            this.AddMultipleTransactionsToChainblock();

            var expected = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            var actual = this.chainblock.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Sender1000")]
        public void GetBySenderOrderedByAmountDescendingMethod_WhenTransactionWithGivenSenderDoesNotExist_ThenShouldThrowException(string sender)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetBySenderOrderedByAmountDescending(sender)
                , $"Transaction with {sender} sender does not exist.");
        }

        [Test]
        [TestCase("Sender1000")]
        public void GetBySenderOrderedByAmountDescendingMethod_WhenTransactionWithGivenSenderExist_ThenShouldReturnCorrectResult(string sender)
        {
            this.AddMultipleTransactionsToChainblock();

            this.chainblock
                .Add(new Transaction(1010, TransactionStatus.Aborted, "Sender1000", "Receiver1000", 100));

            var expected = this.chainblock.GetBySenderOrderedByAmountDescending(sender);

            var actual = this.chainblock.Where(t => t.From == sender).OrderByDescending(t => t.Amount);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Receiver1000")]
        public void GetByReceiverOrderedByAmountThenByIdMethod_WhenTransactionWithGivenReceiverDoesNotExist_ThenShouldThrowException(string receiver)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetByReceiverOrderedByAmountThenById(receiver)
                , $"Transaction with {receiver} receiver does not exist.");
        }

        [Test]
        [TestCase("Receiver1000")]
        public void GetByReceiverOrderedByAmountThenByIdMethod_WhenTransactionWithGivenReceiverExist_ThenShouldReturnCorrectResult(string receiver)
        {
            this.AddMultipleTransactionsToChainblock();

            this.chainblock
                .Add(new Transaction(1010, TransactionStatus.Aborted, "Sender1000", "Receiver1000", 100));

            var expected = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver);

            var actual = this.chainblock.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized, 500)]
        public void GetByTransactionStatusAndMaximumAmountMethod_WhenTransactionWithGivenStatusDoesNotExist_ThenShouldReturnEmptyCollection(TransactionStatus status, decimal amount)
        {
            var expected = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount);
            var actual = Enumerable.Empty<ITransaction>();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(TransactionStatus.Unauthorized, 500)]
        public void GetByTransactionStatusAndMaximumAmountMethod_WhenTransactionWithGivenStatusExist_ThenShouldReturnCorrectResult(TransactionStatus status, decimal amount)
        {
            this.AddMultipleTransactionsToChainblock();

            var expected = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount);

            var actual = this.chainblock
                .Where(t => t.Status == status).OrderByDescending(t => t.Amount).Where(t => t.Amount <= amount);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Sender1000", 500)]
        public void GetBySenderAndMinimumAmountDescendingMethod_WhenTransactionWithGivenSenderDoesNotExist_ThenShouldThrowException(string sender, decimal amount)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount)
                , $"Transaction with {sender} sender does not exist.");
        }

        [Test]
        [TestCase("Sender1000", 500)]
        public void GetBySenderAndMinimumAmountDescendingMethod_WhenTransactionWithGivenSenderExist_ThenShouldReturnCorrectResult(string sender, decimal amount)
        {
            this.AddMultipleTransactionsToChainblock();

            this.chainblock
                .Add(new Transaction(1010, TransactionStatus.Aborted, "Sender1000", "Receiver1000", 100));

            var expected = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);

            var actual = this.chainblock.Where(t => t.From == sender).Where(t => t.Amount > amount).OrderByDescending(t => t.Amount);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Receiver1000", 90, 800)]
        public void GetByReceiverAndAmountRangeMethod_WhenTransactionWithGivenReceiverDoesNotExist_ThenShouldThrowException(string receiver, decimal minAmount, decimal maxAmount)
        {
            Assert.Throws<InvalidOperationException>(() =>
                    this.chainblock.GetByReceiverAndAmountRange(receiver, minAmount, maxAmount)
                , $"Transaction with {receiver} receiver does not exist.");
        }

        [Test]
        [TestCase("Receiver1000", 90, 800)]
        public void GetByReceiverAndAmountRangeMethod_WhenTransactionWithGivenReceiverExist_ThenShouldReturnCorrectResult(string receiver, decimal minAmount, decimal maxAmount)
        {
            this.AddMultipleTransactionsToChainblock();

            this.chainblock
                .Add(new Transaction(1010, TransactionStatus.Aborted, "Sender1000", "Receiver1000", 100));

            var expected = this.chainblock.GetByReceiverAndAmountRange(receiver, minAmount, maxAmount);

            var actual = this.chainblock
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .Where(t => t.Amount >= minAmount && t.Amount < maxAmount)
                .OrderBy(t => t.Id);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(290, 800)]
        public void GetAllInAmountRangeMethod_WhenTransactionWithGivenStatusDoesNotExist_ThenShouldReturnEmptyCollection(decimal minAmount, decimal maxAmount)
        {
            var expected = this.chainblock.GetAllInAmountRange(minAmount, maxAmount);
            var actual = Enumerable.Empty<ITransaction>();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(290, 800)]
        public void GetAllInAmountRangeMethod_WhenTransactionWithGivenStatusExist_ThenShouldReturnCorrectResult(decimal minAmount, decimal maxAmount)
        {
            this.AddMultipleTransactionsToChainblock();

            var expected = this.chainblock.GetAllInAmountRange(minAmount, maxAmount);

            var actual = this.chainblock
                .Where(t => t.Amount >= minAmount && t.Amount < maxAmount);

            Assert.AreEqual(expected, actual);
        }

        private void AddMultipleTransactionsToChainblock()
        {
            this.chainblock
                .Add(new Transaction(800, TransactionStatus.Successful, "Sender800", "Receiver800", 800));
            this.chainblock
                .Add(new Transaction(1000, TransactionStatus.Unauthorized, "Sender1000", "Receiver1000", 1000));
            this.chainblock
                .Add(new Transaction(200, TransactionStatus.Successful, "Sender200", "Receiver200", 200));
            this.chainblock
                .Add(new Transaction(300, TransactionStatus.Aborted, "Sender300", "Receiver300", 300));
            this.chainblock
                .Add(new Transaction(4000, TransactionStatus.Failed, "Sender4000", "Receiver4000", 4000));
            this.chainblock
                .Add(new Transaction(2000, TransactionStatus.Failed, "Sender2000", "Receiver2000", 2000));
            this.chainblock
                .Add(new Transaction(100, TransactionStatus.Unauthorized, "Sender1", "Receiver1", 100));
        }
    }
}