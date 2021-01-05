namespace Chainblock.Tests
{
    using NUnit.Framework;

    using System;

    [TestFixture]
    public class TransactionTests
    {
        private const int Id = 10;
        private const TransactionStatus TransactionStatus = global::Chainblock.TransactionStatus.Successful;
        private const string From = "The sender";
        private const string To = "The receiver";
        private const decimal Amount = 8000;

        private Transaction transaction;

        [SetUp]
        public void Setup()
        {
            this.transaction = new Transaction(Id, TransactionStatus, From, To, Amount);
        }

        [Test]
        public void IfInConstructorWorkCorrectly()
        {
            var expectedId = Id;
            var actualId = this.transaction.Id;
            Assert.AreEqual(expectedId, actualId);

            var expectedStatus = TransactionStatus;
            var actualStatus = this.transaction.Status;
            Assert.AreEqual(expectedStatus, actualStatus);

            var expectedFrom = From;
            var actualFrom = this.transaction.From;
            Assert.AreEqual(expectedFrom, actualFrom);

            var expectedTo = To;
            var actualTo = this.transaction.To;
            Assert.AreEqual(expectedTo, actualTo);

            var expectedAmount = Amount;
            var actualAmount = this.transaction.Amount;
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void IfAllStatusWorkCorrectly()
        {
            var expectedStatusSuccessful = TransactionStatus.Successful.ToString();
            var actualStatusSuccessful = "Successful";
            Assert.AreEqual(expectedStatusSuccessful, actualStatusSuccessful);

            var expectedStatusFailed = TransactionStatus.Failed.ToString();
            var actualStatusFailed = "Failed";
            Assert.AreEqual(expectedStatusFailed, actualStatusFailed);

            var expectedStatusAborted = TransactionStatus.Aborted.ToString();
            var actualStatusAborted = "Aborted";
            Assert.AreEqual(expectedStatusAborted, actualStatusAborted);

            var expectedStatusUnauthorized = TransactionStatus.Unauthorized.ToString();
            var actualStatusUnauthorized = "Unauthorized";
            Assert.AreEqual(expectedStatusUnauthorized, actualStatusUnauthorized);
        }

        [Test]
        public void ThrowExceptionInConstructorWhenFromIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                    this.transaction = new Transaction(Id, TransactionStatus, null, To, Amount)
                , "From cannot be null or empty.");
        }

        [Test]
        public void ThrowExceptionInConstructorWhenToIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                    this.transaction = new Transaction(Id, TransactionStatus, From, null, Amount)
                , "To cannot be null or empty.");
        }

        [Test]
        public void ThrowExceptionInConstructorWhenAmountIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                    this.transaction = new Transaction(Id, TransactionStatus, From, To, -100)
                , "Amount cannot be negative.");
        }
    }
}