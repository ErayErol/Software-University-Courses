using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Dictionary<string, Item> vaultCells;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
            this.vaultCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            this.item = new Item("Owner", "10");
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(this.bankVault.VaultCells, this.vaultCells);
        }

        [Test]
        public void Test1()
        {
            Assert.Throws<ArgumentException>(() =>
                    this.bankVault.AddItem("ASD", this.item));
        }

        [Test]
        public void Test2()
        {
            this.bankVault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() =>
            this.bankVault.AddItem("A1", null));
        }

        [Test]
        public void Test3()
        {
            this.bankVault.AddItem("A1", this.item);
            
            Assert.Throws<InvalidOperationException>(() =>
                this.bankVault.AddItem("C4", this.item));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(this.bankVault.AddItem("A1", this.item), $"Item:{this.item.ItemId} saved successfully!");
        }

        [Test]
        public void Test5()
        {
            Assert.Throws<ArgumentException>(() =>
                this.bankVault.RemoveItem("AASD", this.item));
        }

        [Test]
        public void Test6()
        {
            Assert.Throws<ArgumentException>(() =>
                this.bankVault.RemoveItem("A1", this.item));
        }

        [Test]
        public void Test7()
        {
            this.bankVault.AddItem("A1", this.item);

            Assert.AreEqual(this.bankVault.RemoveItem("A1", this.item), $"Remove item:{this.item.ItemId} successfully!");
        }
    }
}