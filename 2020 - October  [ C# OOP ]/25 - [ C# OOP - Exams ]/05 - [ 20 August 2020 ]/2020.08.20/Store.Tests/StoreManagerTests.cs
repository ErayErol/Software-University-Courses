using System;
using NUnit.Framework;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager storeManager;

        [SetUp]
        public void Setup()
        {
            this.storeManager = new StoreManager();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(this.storeManager.Count, 0);
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this.storeManager.AddProduct(null));
        }

        [Test]
        public void Test3()
        {
            Product product = new Product("Name", 5, 5);
            this.storeManager.AddProduct(product);
            Assert.AreEqual(this.storeManager.Count, 1);
        }

        [Test]
        public void Test4()
        {
            Product product = new Product("Name", -5, 5);

            Assert.Throws<ArgumentException>(() =>
                this.storeManager.AddProduct(product));
        }

        [Test]
        public void Test5()
        {
            Product product = new Product("Name", 5, 5);
            this.storeManager.AddProduct(product);

            Assert.AreEqual(this.storeManager.Products.Count, 1);
        }

        [Test]
        public void Test6()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this.storeManager.BuyProduct(null, 5));
        }

        [Test]
        public void Test7()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this.storeManager.BuyProduct("null", 5));
        }

        [Test]
        public void Test8()
        {
            Product product = new Product("Name", 5, 5);
            this.storeManager.AddProduct(product);

            Assert.Throws<ArgumentException>(() =>
                this.storeManager.BuyProduct("Name", 15));
        }

        [Test]
        public void Test9()
        {
            Product product = new Product("Name", 5, 5);
            this.storeManager.AddProduct(product);

            Assert.AreEqual(this.storeManager.BuyProduct("Name", 1), 5);
        }

        [Test]
        public void Test10()
        {
            Assert.AreEqual(this.storeManager.GetTheMostExpensiveProduct(), null);
        }

        [Test]
        public void Test11()
        {
            Product product = new Product("Name1", 5, 5);
            this.storeManager.AddProduct(product);

            Product product2 = new Product("Name2", 3, 35);
            this.storeManager.AddProduct(product2);

            Product product3 = new Product("Name3", 1, 15);
            this.storeManager.AddProduct(product3);

            Assert.AreEqual(this.storeManager.GetTheMostExpensiveProduct(), product2);
        }
    }
}