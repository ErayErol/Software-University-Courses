using System;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        private string computerName = "CompName";

        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer(computerName);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(this.computer.Name, computerName);
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<ArgumentNullException>(() => this.computer = new Computer(null));
        }

        [Test]
        public void Test3()
        {
            Part part = new Part("PartName,", 30);
            this.computer.AddPart(part);

            Assert.AreEqual(this.computer.Parts.Count, 1);
        }

        [Test]
        public void Test4()
        {
            Part part = new Part("PartName,", 30);
            Part part2 = new Part("PartName2,", 50);
            Part part3 = new Part("PartName3,", 90);
            this.computer.AddPart(part);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.TotalPrice, 170);
        }

        [Test]
        public void Test5()
        {
            Assert.Throws<InvalidOperationException>(() =>
                this.computer.AddPart(null));
        }

        [Test]
        public void Test6()
        {
            Part part = new Part("PartName,", 30);
            Part part2 = new Part("PartName2,", 50);
            Part part3 = new Part("PartName3,", 90);
            this.computer.AddPart(part);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.RemovePart(part2), true);
        }

        [Test]
        public void Test7()
        {
            Part part = new Part("PartName,", 30);
            Part part2 = new Part("PartName2,", 50);
            Part part3 = new Part("PartName3,", 90);
            this.computer.AddPart(part);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.RemovePart(part2), false);
        }

        [Test]
        public void Test8()
        {
            Part part = new Part("PartName,", 30);
            Part part2 = new Part("PartName2,", 50);
            Part part3 = new Part("PartName3,", 90);
            this.computer.AddPart(part);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.GetPart(part2.Name), null);
        }

        [Test]
        public void Test9()
        {
            Part part = new Part("PartName,", 30);
            Part part2 = new Part("PartName2,", 50);
            Part part3 = new Part("PartName3,", 90);
            this.computer.AddPart(part);
            this.computer.AddPart(part2);
            this.computer.AddPart(part3);

            Assert.AreEqual(this.computer.GetPart(part2.Name), part2);
        }
    }
}