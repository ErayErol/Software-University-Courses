using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Lenovo");
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(this.computer.Name, "Lenovo");
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<ArgumentNullException>(() =>
                this.computer = new Computer(""));
        }

        [Test]
        public void Test3()
        {
            var part1 = new Part("Part1", 1);
            var part2 = new Part("Part2", 2);
            var part3 = new Part("Part3", 3);
            this.computer.AddPart(part1);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.Parts.Count, 3);
        }

        [Test]
        public void Test4()
        {
            var part1 = new Part("Part1", 1);
            var part2 = new Part("Part2", 2);
            var part3 = new Part("Part3", 3);
            this.computer.AddPart(part1);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.TotalPrice, 6);
        }

        [Test]
        public void Test14()
        {
            Assert.AreEqual(this.computer.TotalPrice, 0);
        }

        [Test]
        public void Test5()
        {
            var part1 = new Part("Part1", 1);
            var part2 = new Part("Part2", 2);
            var part3 = new Part("Part3", 3);
            this.computer.AddPart(part1);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.GetPart("Part1"), part1);
        }

        [Test]
        public void Test6()
        {
            var part1 = new Part("Part1", 1);
            var part2 = new Part("Part2", 2);
            var part3 = new Part("Part3", 3);
            this.computer.AddPart(part1);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.RemovePart(part3), true);
        }

        [Test]
        public void Test7()
        {
            var part1 = new Part("Part1", 1);
            var part2 = new Part("Part2", 2);
            var part3 = new Part("Part3", 3);
            this.computer.AddPart(part1);
            this.computer.AddPart(part2);

            Assert.AreEqual(this.computer.RemovePart(part3), false);
        }

        [Test]
        public void Test8()
        {
            Assert.Throws<InvalidOperationException>(() =>
                this.computer.AddPart(null));
        }

        [Test]
        public void Test9()
        {
            var part1 = new Part("Part1", 1);
            var part2 = new Part("Part2", 2);
            var part3 = new Part("Part3", 3);
            this.computer.AddPart(part1);
            this.computer.AddPart(part2);

            Assert.AreEqual(this.computer.RemovePart(null), false);
        }

        [Test]
        public void Test10()
        {
            var part2 = new Part("Part2", 2);
            var part3 = new Part("Part3", 3);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.GetPart("Part1"), null);
        }
    }
}