namespace Problem03.ReversedList.Tests
{
    using System;
    using NUnit.Framework;
    using Problem03.ReversedList;

    [TestFixture]
    public class ListTests
    {
        private readonly Random _random = new Random();

        [Test]
        public void AddShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);

            for (var i = 1; i <= count; i++)
            {
                var randomNumber = this._random.Next();

                list.Add(randomNumber);
                Assert.AreEqual(i, list.Count);
            }
        }

        [Test]
        public void IndexerGetterShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomNumber = this._random.Next();

                list.Add(randomNumber);

                // We should set it in an array because in an implementation full of bugs the indexer may remove the last added item.
                array[^i] = randomNumber;
            }

            for (var i = 0; i < count; i++)
                Assert.AreEqual(array[i], list[i]);
        }

        [Test]
        public void IndexerGetterShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            for (var i = 0; i < count; i++)
                list.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { var x = list[-(1 + i)]; });
                Assert.Throws<IndexOutOfRangeException>(() => { var x = list[count + i]; });
            }
        }

        [Test]
        public void IndexerSetterShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomNumber = this._random.Next();

                list.Add(0);

                // We should set it in an array because in an implementation full of bugs the indexer may remove the last added item.
                list[i] = randomNumber;
                array[^(i + 1)] = randomNumber;
            }

            for (var i = 0; i < count; i++)
                Assert.AreEqual(array[i], list[i]);
        }

        [Test]
        public void IndexerSetterShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            for (var i = 0; i < count; i++)
                list.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { list[-(1 + i)] = 3; });
                Assert.Throws<IndexOutOfRangeException>(() => { list[count + i] = 3; });
            }
        }

        [Test]
        public void IndexOfShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomNumber = i * 17;

                list.Add(randomNumber);

                // We should set it in an array because in an implementation full of bugs the indexer may remove the last added item.
                array[^i] = randomNumber;
            }

            for (var i = 0; i < count; i++)
                Assert.AreEqual(i, list.IndexOf(array[i]));
        }

        [Test]
        public void IndexOfShouldReturnMinusOneForNonexistentItem()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);

            for (var i = 0; i < count; i++)
                list.Add(i);

            Assert.AreEqual(-1, list.IndexOf(count));
        }

        [Test]
        public void ContainsShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);

            for (var i = 0; i < count; i++)
                list.Add(i);

            for (var i = 0; i < count; i++)
                Assert.True(list.Contains(i));

            Assert.False(list.Contains(count));
        }

        [Test]
        public void GetEnumeratorShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomNumber = i * 17;
                list.Add(randomNumber);

                array[^i] = randomNumber;
            }

            var index = 0;
            foreach (var item in list)
                Assert.AreEqual(array[index++], item);
        }

        [Test]
        public void RemoveAtShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomNumber = this._random.Next();

                list.Add(randomNumber);
                array[^i] = randomNumber;
            }

            var randomIndex = this._random.Next(array.Length);
            list.RemoveAt(randomIndex);
            Assert.AreEqual(array.Length - 1, list.Count);

            for (var i = 0; i < randomIndex - 1; i++)
                Assert.AreEqual(array[i], list[i]);

            for (var i = randomIndex; i < list.Count; i++)
                Assert.AreEqual(array[i + 1], list[i]);
        }

        [Test]
        public void RemoveAtShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            for (var i = 0; i < count; i++)
                list.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAt(-(1 + i)); });
                Assert.Throws<IndexOutOfRangeException>(() => { list.RemoveAt(count + i); });
            }
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                list.Add(i);
                array[^(i + 1)] = i;
            }

            var randomIndex = this._random.Next(array.Length) + 1;
            list.Remove(array[randomIndex]);
            Assert.AreEqual(array.Length - 1, list.Count);

            for (var i = 0; i < randomIndex - 1; i++)
                Assert.AreEqual(array[i], list[i]);

            for (var i = randomIndex; i < list.Count; i++)
                Assert.AreEqual(array[i + 1], list[i]);

            for (var i = 0; i < count; i++)
                Assert.False(list.Remove(count + i));
        }

        [Test]
        public void InsertShouldWorkCorrectly()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);
            var randomInsertIndex = this._random.Next(0, count);
            var randomInsertValue = this._random.Next(count, 100);
            var array = new int[count + 1];

            for (var i = 0; i < count; i++)
            {
                list.Add(i);
                array[i < array.Length - (randomInsertIndex + 1) ? ^(i + 1) : ^(i + 2)] = i;
            }

            array[randomInsertIndex] = randomInsertValue;
            list.Insert(randomInsertIndex, randomInsertValue);
            Assert.AreEqual(array.Length, list.Count);

            for (var i = 0; i < count; i++)
                Assert.AreEqual(array[i], list[i]);
        }

        [Test]
        public void InsertShouldThrowExceptionIfInvalidIndexIsPassed()
        {
            var list = GetList();

            var count = this._random.Next(10, 25);

            for (var i = 0; i < count; i++)
                list.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { list.Insert(-(1 + i), this._random.Next(1, 5)); });
                Assert.Throws<IndexOutOfRangeException>(() => { list.Insert(count + i, this._random.Next(1, 5)); });
            }
        }

        private static IAbstractList<int> GetList() => new ReversedList<int>();
    }
}