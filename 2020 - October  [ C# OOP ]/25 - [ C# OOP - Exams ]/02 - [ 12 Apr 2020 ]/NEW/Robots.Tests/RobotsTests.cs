using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager _robotManager;
        private Robot _robot;
        private Robot _robot2;

        [SetUp]
        public void SetUp()
        {
            this._robotManager = new RobotManager(2);

            this._robot = new Robot("Robot", 5);
            this._robot2 = new Robot("Robot2", 3);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(this._robotManager.Capacity, 2);
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<ArgumentException>(() =>
            this._robotManager = new RobotManager(-10));
        }

        [Test]
        public void Test3()
        {
            this._robotManager.Add(_robot);

            Assert.AreEqual(this._robotManager.Count, 1);
        }

        [Test]
        public void Test4()
        {
            this._robotManager.Add(_robot);

            Assert.Throws<InvalidOperationException>(() =>
                this._robotManager.Add(_robot));
        }

        [Test]
        public void Test5()
        {
            this._robotManager.Add(_robot);
            this._robotManager.Add(_robot2);

            Assert.Throws<InvalidOperationException>(() =>
                this._robotManager.Add(new Robot("Robot3", 4)));
        }

        [Test]
        public void Test6()
        {
            Assert.Throws<InvalidOperationException>(() =>
                this._robotManager.Remove("NoName"));
        }

        [Test]
        public void Test7()
        {
            this._robotManager.Add(_robot);
            this._robotManager.Add(_robot2);
            this._robotManager.Remove("Robot");

            Assert.AreEqual(this._robotManager.Count, 1);
        }

        [Test]
        public void Test8()
        {
            Assert.Throws<InvalidOperationException>(() =>
                this._robotManager.Work("NoName", "NoJob", 3));
        }

        [Test]
        public void Test9()
        {
            this._robotManager.Add(_robot);
            this._robotManager.Add(_robot2);

            Assert.Throws<InvalidOperationException>(() =>
                this._robotManager.Work("Robot", "NoJob", 300));
        }

        [Test]
        public void Test10()
        {
            this._robotManager.Add(_robot);
            this._robotManager.Add(_robot2);
            this._robotManager.Work("Robot", "NoJob", 1);

            Assert.AreEqual(this._robot.Battery, 4);
        }

        [Test]
        public void Test11()
        {
            Assert.Throws<InvalidOperationException>(() =>
                this._robotManager.Charge("NoName"));
        }

        [Test]
        public void Test12()
        {
            this._robotManager.Add(_robot);
            this._robotManager.Work("Robot", "NoJob", 3);
            this._robotManager.Charge("Robot");

            Assert.AreEqual(this._robot.Battery, 5);
            Assert.AreEqual(this._robot.MaximumBattery, 5);
        }
    }
}
