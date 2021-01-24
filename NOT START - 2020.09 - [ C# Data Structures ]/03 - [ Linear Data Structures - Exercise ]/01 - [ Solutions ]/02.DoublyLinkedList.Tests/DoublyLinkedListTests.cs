using NUnit.Framework;

namespace Problem02.DoublyLinkedList.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using DoublyLinkedList;
    using NUnit.Framework;
    using Problem02.DoublyLinkedList;

    [TestFixture]
    public class LinkedListTests
    {
        private readonly Random _random = new Random();

        [Test]
        public void AddFirstShouldWorkAsExpected()
        {
            var list = GetList();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomValue = this._random.Next(100);
                array[count - i] = randomValue;
                list.AddFirst(randomValue);
                Assert.AreEqual(i, list.Count);
            }

            var index = 0;
            foreach (var listElement in list)
                Assert.AreEqual(array[index++], listElement);
        }

        [Test]
        public void AddLastShouldWorkAsExpected()
        {
            var list = GetList();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                list.AddLast(randomValue);
                Assert.AreEqual(i + 1, list.Count);
            }

            var index = 0;
            foreach (var listElement in list)
                Assert.AreEqual(array[index++], listElement);
        }

        [Test]
        public void RemoveFirstShouldWorkAsExpected()
        {
            var list = GetList();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                list.AddLast(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var removedElement = list.RemoveFirst();
                Assert.AreEqual(array[i], removedElement);
                Assert.AreEqual(array.Length - (i + 1), list.Count);
            }
        }

        [Test]
        public void RemoveFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Test]
        public void RemoveLastShouldWorkAsExpected()
        {
            var list = GetList();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                list.AddFirst(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var removedElement = list.RemoveLast();
                Assert.AreEqual(array[i], removedElement);
                Assert.AreEqual(array.Length - (i + 1), list.Count);
            }
        }

        [Test]
        public void RemoveLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Test]
        public void GetFirstShouldWorkAsExpected()
        {
            var list = GetList();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                list.AddLast(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var firstElement = list.GetFirst();
                Assert.AreEqual(array[i], firstElement);

                list.RemoveFirst();
            }
        }

        [Test]
        public void GetFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            Assert.Throws<InvalidOperationException>(() => list.GetFirst());
        }

        [Test]
        public void GetLastShouldWorkAsExpected()
        {
            var list = GetList();
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                list.AddFirst(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                var lastElement = list.GetLast();
                Assert.AreEqual(array[i], lastElement);

                list.RemoveLast();
            }
        }

        [Test]
        public void GetLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            Assert.Throws<InvalidOperationException>(() => list.GetLast());
        }

        [Test]
        public void LinkedListContainsTwoPrivateNodes()
        {
            var linkedListType = typeof(DoublyLinkedList<>);
            var allFields = linkedListType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.FieldType.Name.Contains("Node"))
                .ToList();
            Assert.AreEqual(2, allFields.Count);
        }

        [Test]
        public void NodeContainsPropertyPointingToThePreviousOne()
        {
            var nodeType = typeof(Node<>);
            var allProperties = nodeType.GetProperties().Where(p => p.PropertyType == typeof(Node<>)).ToList();
            Assert.AreEqual(2, allProperties.Count);
        }

        private static IAbstractLinkedList<int> GetList() => new DoublyLinkedList<int>();
    }
}