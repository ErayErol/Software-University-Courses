using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager _computerManager;
        private List<Computer> _computers;

        [SetUp]
        public void Setup()
        {
            this._computerManager = new ComputerManager();
            this._computers = new List<Computer>();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(0, this._computers.Count);
        }

        [Test]
        public void Test2()
        {
            this._computerManager.AddComputer(new Computer("manufacturer", "model", 10));
            this._computers.Add(new Computer("manufacturer", "model", 10));
            Assert.AreEqual(this._computerManager.Count, this._computers.Count);
        }

        [Test]
        public void Test111()
        {
            Assert.AreEqual(this._computerManager.Count, 0);
        }

        [Test]
        public void Test222()
        {
            this._computerManager.AddComputer(new Computer("manufacturer", "model", 10));
            this._computers.Add(new Computer("manufacturer", "model", 10));
            Assert.AreEqual(this._computerManager.Computers.Count, this._computers.Count);
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(this._computerManager.Computers, this._computers);
        }

        [Test]
        public void Test4()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this._computerManager.AddComputer(null));
        }

        [Test]
        public void Test5()
        {
            this._computerManager.AddComputer(new Computer("manufacturer", "model", 10));
            Assert.Throws<ArgumentException>(() =>
                this._computerManager.AddComputer(new Computer("manufacturer", "model", 10)));
        }

        [Test]
        public void Test6()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this._computerManager.RemoveComputer(null, null));
        }

        [Test]
        public void Test7()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this._computerManager.RemoveComputer("m", null));
        }

        [Test]
        public void Test8()
        {
            var comp = new Computer("manufacturer", "model", 10);
            this._computerManager.AddComputer(comp);
            this._computerManager.RemoveComputer(comp.Manufacturer, comp.Model);
            Assert.AreEqual(this._computerManager.Count, 0);
        }

        [Test]
        public void Test9()
        {
            Assert.Throws<ArgumentException>(() =>
                this._computerManager.RemoveComputer("asd1", "asd2"));
        }

        [Test]
        public void Test10()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this._computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void Test11()
        {
            var comp = new Computer("manufacturer", "model", 10);
            var comp2 = new Computer("manufacturer", "model2", 100);
            this._computerManager.AddComputer(comp);
            this._computerManager.AddComputer(comp2);

            ICollection<Computer> computers = this._computerManager.Computers
                .Where(c => c.Manufacturer == "manufacturer")
                .ToList();

            Assert.AreEqual(this._computerManager.GetComputersByManufacturer(comp.Manufacturer), computers);
        }
    }
}