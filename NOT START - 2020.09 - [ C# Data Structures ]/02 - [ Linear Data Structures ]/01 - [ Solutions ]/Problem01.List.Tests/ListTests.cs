namespace Problem01.List.Tests
{
    using System;
    using NUnit.Framework;
    using Problem01.List;

    [TestFixture]
    public class ListTests
    {
        private readonly Random _random = new Random();
        private IAbstractList<int> myList;

        [SetUp]
        public void InitializeList()
        {
            this.myList = new List<int>();
        }

        [Test]
        public void AddShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);

            for (var i = 1; i <= count; i++)
            {
                var randomNumber = this._random.Next();

                myList.Add(randomNumber);
                Assert.AreEqual(i, myList.Count);
            }
        }

        [Test]
        public void IndexerGetterShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomNumber = this._random.Next();

                myList.Add(randomNumber);
                array[i] = randomNumber;
            }

            for (var i = 0; i < count; i++)
                Assert.AreEqual(array[i], myList[i]);
        }

        [Test]
        public void IndexerGetterShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var count = this._random.Next(10, 25);
            for (var i = 0; i < count; i++)
                myList.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { var x = myList[-(1 + i)]; });
                Assert.Throws<IndexOutOfRangeException>(() => { var x = myList[count + i]; });
            }
        }

        [Test]
        public void IndexerSetterShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomNumber = this._random.Next();

                myList.Add(0);
                myList[i] = randomNumber;
                array[i] = randomNumber;
            }

            for (var i = 0; i < count; i++)
                Assert.AreEqual(array[i], myList[i]);
        }

        [Test]
        public void IndexerSetterShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var count = this._random.Next(10, 25);
            for (var i = 0; i < count; i++)
                myList.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { myList[-(1 + i)] = 3; });
                Assert.Throws<IndexOutOfRangeException>(() => { myList[count + i] = 3; });
            }
        }

        [Test]
        public void IndexOfShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomNumber = i * 17;

                myList.Add(randomNumber);
                array[i] = randomNumber;
            }

            for (var i = 0; i < count; i++)
                Assert.AreEqual(i, myList.IndexOf(array[i]));
        }

        [Test]
        public void IndexOfShouldReturnMinusOneForNonexistentItem()
        {
            var count = this._random.Next(10, 25);

            for (var i = 0; i < count; i++)
                myList.Add(i);

            Assert.AreEqual(-1, myList.IndexOf(count));
        }

        [Test]
        public void ContainsShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);

            for (var i = 0; i < count; i++)
                myList.Add(i);

            for (var i = 0; i < count; i++)
                Assert.True(myList.Contains(i));

            Assert.False(myList.Contains(count));
        }

        [Test]
        public void GetEnumeratorShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomNumber = i * 17;
                myList.Add(randomNumber);

                array[i] = randomNumber;
            }

            var index = 0;
            foreach (var item in myList)
                Assert.AreEqual(array[index++], item);
        }

        [Test]
        public void RemoveAtShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                var randomNumber = this._random.Next();

                myList.Add(randomNumber);
                array[i] = randomNumber;
            }

            var randomIndex = this._random.Next(array.Length);
            myList.RemoveAt(randomIndex);
            Assert.AreEqual(array.Length - 1, myList.Count);

            for (var i = 0; i < randomIndex - 1; i++)
                Assert.AreEqual(array[i], myList[i]);

            for (var i = randomIndex; i < myList.Count; i++)
                Assert.AreEqual(array[i + 1], myList[i]);
        }

        [Test]
        public void RemoveAtShouldThrowAnExceptionIfInvalidIndexIsPassed()
        {
            var count = this._random.Next(10, 25);
            for (var i = 0; i < count; i++)
                myList.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { myList.RemoveAt(-(1 + i)); });
                Assert.Throws<IndexOutOfRangeException>(() => { myList.RemoveAt(count + i); });
            }
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);
            var array = new int[count];

            for (var i = 0; i < count; i++)
            {
                myList.Add(i);
                array[i] = i;
            }

            var randomIndex = this._random.Next(array.Length);
            myList.Remove(array[randomIndex]);
            Assert.AreEqual(array.Length - 1, myList.Count);

            for (var i = 0; i < randomIndex - 1; i++)
                Assert.AreEqual(array[i], myList[i]);

            for (var i = randomIndex; i < myList.Count; i++)
                Assert.AreEqual(array[i + 1], myList[i]);

            for (var i = 0; i < count; i++)
                Assert.False(myList.Remove(count + i));
        }

        [Test]
        public void InsertShouldWorkCorrectly()
        {
            var count = this._random.Next(10, 25);
            var randomInsertIndex = this._random.Next(0, count);
            var randomInsertValue = this._random.Next(count, 100);
            var array = new int[count + 1];

            for (var i = 0; i < count; i++)
            {
                myList.Add(i);
                array[i < randomInsertIndex ? i : i + 1] = i;
            }

            array[randomInsertIndex] = randomInsertValue;
            myList.Insert(randomInsertIndex, randomInsertValue);
            Assert.AreEqual(array.Length, myList.Count);

            for (var i = 0; i < count; i++)
                Assert.AreEqual(array[i], myList[i]);
        }

        [Test]
        public void InsertShouldThrowExceptionIfInvalidIndexIsPassed()
        {
            var count = this._random.Next(10, 25);

            for (var i = 0; i < count; i++)
                myList.Add(i);

            for (var i = 0; i < count; i++)
            {
                Assert.Throws<IndexOutOfRangeException>(() => { myList.Insert(-(1 + i), this._random.Next(1, 5)); });
                Assert.Throws<IndexOutOfRangeException>(() => { myList.Insert(count + i, this._random.Next(1, 5)); });
            }
        }
    }
}