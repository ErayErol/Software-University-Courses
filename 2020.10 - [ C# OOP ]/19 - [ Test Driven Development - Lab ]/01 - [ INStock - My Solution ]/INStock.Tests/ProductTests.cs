namespace INStock.Tests
{
    using NUnit.Framework;

    using System;

    [TestFixture]
    public class ProductTests
    {
        private const string Label = "Test";
        private const decimal Price = 10;
        private const int Quantity = 5;

        private Product product;

        [SetUp]
        public void Setup()
        {
            this.product = new Product(Label, Price, Quantity);
        }

        [Test]
        public void IfInConstructorLabelWorkCorrectly()
        {
            var expectedLabel = Label;
            var actualLabel = this.product.Label;

            Assert.AreEqual(expectedLabel, actualLabel);
        }

        [Test]
        public void IfInConstructorLabelIsNullThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            this.product = new Product(null, Price, Quantity)
            , "Label cannot be null or empty.");
        }

        [Test]
        public void IfInConstructorPriceIsLessOrEqualZeroThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            this.product = new Product(Label, -10, Quantity)
            , "Price cannot be zero or negative");
        }

        [Test]
        public void IfInConstructorQuantityIsLessOrEqualZeroThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            this.product = new Product(Label, Price, -10)
            , "Qunatity cannot be zero or negative");
        }

        [Test]
        public void IfCompareToWorkCorrectlyAndReturnNegativeWhenOtherIsBiggerThanCurrent()
        {
            var other = new Product(Label, 100, Quantity);

            var expected = -1;
            var actual = this.product.CompareTo(other);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfCompareToWorkCorrectlyAndReturnZeroWhenItsEqual()
        {
            var other = new Product(Label, Price, Quantity);

            var expected = 0;
            var actual = this.product.CompareTo(other);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfCompareToWorkCorrectlyAndReturnPositiveWhenCurrentIsBiggerThanOther()
        {
            var other = new Product(Label, 1, Quantity);

            var expected = 1;
            var actual = this.product.CompareTo(other);

            Assert.AreEqual(expected, actual);
        }
    }
}