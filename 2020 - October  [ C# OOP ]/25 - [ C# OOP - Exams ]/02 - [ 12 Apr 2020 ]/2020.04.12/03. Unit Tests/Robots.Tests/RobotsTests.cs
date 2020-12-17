namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            this.robot = new Robot("RobotTest", 100);
            this.robotManager = new RobotManager(10);

        }

        [Test]
        public void Constructor_When_Then1()
        {
            Assert.AreEqual(this.robot.Name, "RobotTest");
            Assert.AreEqual(this.robot.MaximumBattery, 100);
            Assert.AreEqual(this.robot.Battery, 100);
        }

        [Test]
        public void Constructor_When_Then2()
        {
            this.robot.Name = "RobotTest2";
            this.robot.Battery = 200;

            Assert.AreEqual(this.robot.Name, "RobotTest2");
            Assert.AreEqual(this.robot.MaximumBattery, 100);
            Assert.AreEqual(this.robot.Battery, 200);
        }

        [Test]
        public void Constructor_When_Then3()
        {
            robot.Name = null;
            robot.Battery = 500;

            Assert.AreEqual(robot.Name, null);
            Assert.AreEqual(robot.MaximumBattery, 100);
            Assert.AreEqual(robot.Battery, 500);
        }

        [Test]
        public void Constructor_When_Then4()
        {
            Assert.AreEqual(this.robotManager.Capacity, 10);
        }

        [Test]
        public void Constructor_When_Then5()
        {
            Assert.Throws<ArgumentException>(() =>
            this.robotManager = new RobotManager(-10)
                , "Invalid capacity!");
        }

        [Test]
        public void Add_When_Then()
        {
            this.robotManager.Add(robot);

            Assert.AreEqual(this.robotManager.Count, 1);
        }

        [Test]
        public void Add_When_Then2()
        {
            this.robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
                    this.robotManager.Add(robot)
                , $"There is already a robot with name {robot.Name}!");
        }

        [Test]
        public void Add_When_Then3()
        {
            this.robotManager = new RobotManager(2);
            this.robotManager.Add(robot);
            this.robotManager.Add(new Robot("Testttt", 900));
            Assert.Throws<InvalidOperationException>(() =>
                this.robotManager.Add(new Robot("Testttt2", 300))
                , "Not enough capacity!");
        }

        [Test]
        public void Remove_When_Then()
        {
            this.robotManager.Add(robot);
            this.robotManager.Add(new Robot("Testttt", 900));
            this.robotManager.Remove(robot.Name);

            Assert.AreEqual(this.robotManager.Count, 1);
        }

        [Test]
        public void Remove_When_Then3()
        {
            this.robotManager.Add(new Robot("Testttt", 900));
            Assert.Throws<InvalidOperationException>(() =>
                    this.robotManager.Remove(robot.Name)
                , $"Robot with the name {robot.Name} doesn't exist!");
        }

        [Test]
        public void Work_When_Then1()
        {
            this.robotManager.Add(new Robot("Testttt", 900));
            Assert.Throws<InvalidOperationException>(() =>
                    this.robotManager.Work(robot.Name, "Dev", 10)
                , $"Robot with the name {robot.Name} doesn't exist!");
        }

        [Test]
        public void Work_When_Then3()
        {
            this.robotManager.Add(new Robot("Testttt", 900));
            Assert.Throws<InvalidOperationException>(() =>
                    this.robotManager.Work("Testttt", "Dev", 1000)
                , $"Testttt doesn't have enough battery!");
        }

        [Test]
        public void Work_When_Then()
        {
            this.robotManager.Add(robot);
            this.robotManager.Add(new Robot("Testttt", 900));

            this.robotManager.Work(robot.Name, "Dev", 5);

            Assert.AreEqual(this.robot.Battery, 95);
        }

        [Test]
        public void Charge_When_Then1()
        {
            this.robotManager.Add(new Robot("Testttt", 900));
            Assert.Throws<InvalidOperationException>(() =>
                    this.robotManager.Charge(robot.Name)
                , $"Robot with the name {robot.Name} doesn't exist!");
        }

        [Test]
        public void Charge_When_Then2()
        {
            this.robotManager.Add(robot);
            this.robot.Battery = 200;
            this.robotManager.Add(new Robot("Testttt", 900));
            this.robotManager.Charge(robot.Name);

            Assert.AreEqual(this.robot.Battery, 100);
        }
    }
}
