namespace SinglyLinkedList.Tests
{
    using System;
    using NUnit.Framework;
    using Problem04.SinglyLinkedList;

    [TestFixture]
    public class SinglyLinkedListTests
    {
        private readonly Random _random = new Random();
        private IAbstractLinkedList<int> _list;

        [SetUp]
        public void InitializeLinkedList()
        {
            this._list = new SinglyLinkedList<int>();
        }

        [Test]
        public void AddFirstShouldWorkAsExpected()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomValue = this._random.Next(100);
                array[count - i] = randomValue;
                _list.AddFirst(randomValue);
                Assert.AreEqual(i, _list.Count);
            }

            var index = 0;
            foreach (var listElement in _list)
                Assert.AreEqual(array[index++], listElement);
        }

        [Test]
        public void AddLastShouldWorkAsExpected()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                _list.AddLast(randomValue);
                Assert.AreEqual(i + 1, _list.Count);
            }

            var index = 0;
            foreach (var listElement in _list)
                Assert.AreEqual(array[index++], listElement);
        }

        [Test]
        public void RemoveFirstShouldWorkAsExpected()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                _list.AddLast(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var removedElement = _list.RemoveFirst();
                Assert.AreEqual(array[i], removedElement);
                Assert.AreEqual(array.Length - (i + 1), _list.Count);
            }
        }

        [Test]
        public void RemoveFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => _list.RemoveFirst());
        }

        [Test]
        public void RemoveLastShouldWorkAsExpected()
        {
            var count = 5;
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                _list.AddFirst(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var removedElement = _list.RemoveLast();
                Assert.AreEqual(array[i], removedElement);
                Assert.AreEqual(array.Length - (i + 1), _list.Count);
            }
        }

        [Test]
        public void RemoveLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => _list.RemoveLast());
        }

        [Test]
        public void GetFirstShouldWorkAsExpected()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                _list.AddLast(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var firstElement = _list.GetFirst();
                Assert.AreEqual(array[i], firstElement);

                _list.RemoveFirst();
            }
        }

        [Test]
        public void GetFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => _list.GetFirst());
        }

        [Test]
        public void GetLastShouldWorkAsExpected()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                _list.AddFirst(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var lastElement = _list.GetLast();
                Assert.AreEqual(array[i], lastElement);

                _list.RemoveLast();
            }
        }

        [Test]
        public void GetLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => _list.GetLast());
        }
    }
}