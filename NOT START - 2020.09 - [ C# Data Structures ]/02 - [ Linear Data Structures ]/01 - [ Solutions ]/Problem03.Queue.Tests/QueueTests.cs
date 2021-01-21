namespace Problem03.Queue.Tests
{
    using System;
    using NUnit.Framework;
    using Problem03.Queue;

    [TestFixture]
    public class QueueTests
    {
        private readonly Random random = new Random();
        private IAbstractQueue<int> _queue;

        [SetUp]
        public void InitializeQueue()
        {
            this._queue = new Queue<int>();
        }

        [Test]
        public void EnqueueShouldAddElementAtTheTop()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                _queue.Enqueue(randomValue);
                Assert.AreEqual(i + 1, _queue.Count);
            }

            var index = 0;
            foreach (var queueElement in _queue)
            {
                Assert.AreEqual(array[index++], queueElement);
            }
        }

        [Test]
        public void DequeueShouldRemoveTheLastElement()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                _queue.Enqueue(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], _queue.Dequeue());
                Assert.AreEqual(array.Length - (i + 1), _queue.Count);
            }
        }

        [Test]
        public void DequeueShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
        }

        [Test]
        public void PeekShouldReturnTheLastElementWithoutRemovingIt()
        {
            var count = this.random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this.random.Next(100);
                array[i] = randomValue;
                _queue.Enqueue(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], _queue.Peek());
                Assert.AreEqual(array.Length - i, _queue.Count);
                _queue.Dequeue();
            }
        }

        [Test]
        public void PeekShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Peek());
        }

        [Test]
        public void ContainsShouldWorkAsExpected()
        {
            var count = this.random.Next(10, 30);

            for (var i = 0; i < count; i++)
                _queue.Enqueue(i);

            for (var i = 0; i < count; i++)
            {
                Assert.IsTrue(_queue.Contains(i));
            }

            Assert.IsFalse(_queue.Contains(count));
        }
    }
}