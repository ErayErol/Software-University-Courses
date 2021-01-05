namespace INStock.Tests
{
    using NUnit.Framework;

    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private const string ProductLabel = "Test";
        private const decimal ProductPrice = 10;
        private const int ProductQuantity = 5;

        private const string AnotherProductLabel = "Another Test";
        private const decimal AnotherProductPrice = 80;
        private const int AnotherProductQuantity = 8;

        private ProductStock productStock;
        private Product product;
        private Product anotherProduct;

        [SetUp]
        public void Setup()
        {
            this.productStock = new ProductStock();
            this.product = new Product(ProductLabel, ProductPrice, ProductQuantity);
            this.anotherProduct = new Product(AnotherProductLabel, AnotherProductPrice, AnotherProductQuantity);
        }

        [Test]
        public void AddMethodShouldSaveTheProductCorrectly()
        {
            this.productStock.Add(this.product);

            var productInStock = this.productStock.FindByLabel(ProductLabel);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(ProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(ProductQuantity));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenTryToAddSameProductLabelTwice()
        {
            this.productStock.Add(this.product);

            Assert.Throws<ArgumentException>(() =>
            this.productStock.Add(this.product)
            , $"A product with {this.product.Label} label already exist.");
        }

        [Test]
        public void AddMethodShouldSaveTheTwoProductCorrectly()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var firstProductInStock = this.productStock.FindByLabel(ProductLabel);
            var secondProductInStock = this.productStock.FindByLabel(AnotherProductLabel);

            Assert.That(firstProductInStock, Is.Not.Null);
            Assert.That(firstProductInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(firstProductInStock.Price, Is.EqualTo(ProductPrice));
            Assert.That(firstProductInStock.Quantity, Is.EqualTo(ProductQuantity));

            Assert.That(secondProductInStock, Is.Not.Null);
            Assert.That(secondProductInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(secondProductInStock.Price, Is.EqualTo(AnotherProductPrice));
            Assert.That(secondProductInStock.Quantity, Is.EqualTo(AnotherProductQuantity));
        }

        [Test]
        public void ContainsMethodShouldWorkCorrectlyWhenProductExist()
        {
            this.productStock.Add(this.product);

            var actualResult = this.productStock.Contains(this.product);

            Assert.AreEqual(true, actualResult);
        }

        [Test]
        public void ContainsMethodShouldWorkCorrectlyWhenProductDontExist()
        {
            var actualResult = this.productStock.Contains(this.product);

            Assert.AreEqual(false, actualResult);
        }

        [Test]
        public void ContainsMethodShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.productStock.Contains(null)
            , "Product cannot be null.");
        }

        [Test]
        public void CountShouldWorkCorrectly()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var expectedResult = 2;
            var actualResult = this.productStock.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindMethodShouldWorkCorrectly()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock.Find(1);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(AnotherProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(AnotherProductQuantity));
        }

        [Test]
        public void FindMethodShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            Assert.Throws<IndexOutOfRangeException>(() =>
            this.productStock.Find(5)
            , "Doesn't exist product with this index.");
        }

        [Test]
        public void FindMethodShouldThrowExceptionWhenIndexIsNegative()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            Assert.Throws<IndexOutOfRangeException>(() =>
            this.productStock.Find(-5)
            , "Product index cannot be negative.");
        }

        [Test]
        public void FindByLabelMethodShouldThrowExceptionWhenProductLabelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.productStock.FindByLabel(null)
            , "Product label cannot be null.");
        }

        [Test]
        public void FindByLabelMethodShouldThrowExceptionWhenProductLabelDoesNotExist()
        {
            this.productStock.Add(this.product);

            Assert.Throws<ArgumentException>(() =>
            this.productStock.FindByLabel(AnotherProductLabel)
            , $"Product with {AnotherProductLabel} label does not exist in stock.");
        }

        [Test]
        public void FindByLabelMethodShouldWorkCorrectly()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock.FindByLabel(ProductLabel);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(ProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(ProductQuantity));
        }

        [Test]
        public void FindAllInPriceRangeMethodShouldReturnEmptyCollectionWhenNoMatch()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindAllInRange(20, 50);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllInPriceRangeMethodShouldReturnCorrectResultInDescendingOrder()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindAllInRange(20, 800).ToList();

            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0].Price, Is.EqualTo(760));
            Assert.That(result[1].Price, Is.EqualTo(600));
            Assert.That(result[2].Price, Is.EqualTo(300));
            Assert.That(result[3].Price, Is.EqualTo(100));
        }

        [Test]
        public void FindAllByPriceMethodShouldReturnEmptyCollectionWhenNoMatch()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindAllByPrice(8000);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByPriceMethodShouldWorkCorrectly()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindAllByPrice(1000).ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Label, Is.EqualTo("3"));
            Assert.That(result[1].Label, Is.EqualTo("8"));
        }

        [Test]
        public void FindMostExpensiveProductMethodShouldThrowExceptionWhenProductStockIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
                this.productStock.FindMostExpensiveProduct()
                , "Product stock is empty.");
        }

        [Test]
        public void FindMostExpensiveProductMethodShouldWorkCorrectly()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindMostExpensiveProduct();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Label, Is.EqualTo("3"));
            Assert.That(result.Price, Is.EqualTo(1000));
            Assert.That(result.Quantity, Is.EqualTo(300));
        }

        [Test]
        public void FindAllByQuantityMethodShouldReturnEmptyCollectionWhenNoMatch()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindAllByQuantity(8000);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByQuantityMethodShouldWorkCorrectly()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.FindAllByQuantity(500).ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Label, Is.EqualTo("5"));
        }

        [Test]
        public void GetEnumeratorMethodShouldWorkCorrectly()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.ToList();

            Assert.That(result.Count, Is.EqualTo(8));
            Assert.That(result[0].Label, Is.EqualTo("1"));
            Assert.That(result[1].Label, Is.EqualTo("2"));
            Assert.That(result[2].Label, Is.EqualTo("3"));
            Assert.That(result[3].Label, Is.EqualTo("4"));
            Assert.That(result[4].Label, Is.EqualTo("5"));
            Assert.That(result[5].Label, Is.EqualTo("6"));
            Assert.That(result[6].Label, Is.EqualTo("7"));
            Assert.That(result[7].Label, Is.EqualTo("8"));
        }

        [Test]
        public void GetIndexShouldWorkCorrectly()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productInStock = this.productStock[1];

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(AnotherProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(AnotherProductQuantity));
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var product = this.productStock[5];
            }, "Doesn't exist product with this index.");
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsNegative()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var product = this.productStock[-5];
            }, "Product index cannot be negative.");
        }

        [Test]
        public void SetIndexShouldWorkCorrectly()
        {
            this.AddMultipleProductsToProductStock();

            this.productStock[3] = anotherProduct;

            var productInStock = this.productStock[3];

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(AnotherProductPrice));
            Assert.That(productInStock.Quantity, Is.EqualTo(AnotherProductQuantity));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            this.AddMultipleProductsToProductStock();

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock[17] = anotherProduct;
            }, "Doesn't exist product with this index.");
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsNegative()
        {
            this.AddMultipleProductsToProductStock();

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock[-17] = anotherProduct;
            }, "Product index cannot be negative.");
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenProductStockIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                    this.productStock.Remove(null)
                , "Product stock is null.");
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectlyWhenTryToRemoveProductThatExist()
        {
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            var productToRemove = productStock.Find(0);
            var result = this.productStock.Remove(productToRemove);

            Assert.That(result, Is.True);
            Assert.That(this.productStock.Count, Is.EqualTo(1));
            Assert.That(this.productStock[0].Label, Is.EqualTo(AnotherProductLabel));
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectlyWhenTryToRemoveProductThatDoesNotExist()
        {
            this.AddMultipleProductsToProductStock();

            var result = this.productStock.Remove(this.product);

            Assert.That(result, Is.False);
            Assert.That(this.productStock.Count, Is.EqualTo(8));
        }

        private void AddMultipleProductsToProductStock()
        {
            this.productStock.Add(new Product("1", 600, 100));
            this.productStock.Add(new Product("2", 1, 200));
            this.productStock.Add(new Product("3", 1000, 300));
            this.productStock.Add(new Product("4", 300, 400));
            this.productStock.Add(new Product("5", 760, 500));
            this.productStock.Add(new Product("6", 5, 600));
            this.productStock.Add(new Product("7", 100, 700));
            this.productStock.Add(new Product("8", 1000, 800));
        }
    }
}