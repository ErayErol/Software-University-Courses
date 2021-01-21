namespace Problem02.Stack.Tests
{
    using System;
    using NUnit.Framework;
    using Problem02.Stack;

    [TestFixture]
    public class StackTests
    {
        private readonly Random _random = new Random();
        private IAbstractStack<int> _stack;

        [SetUp]
        public void InitializeStack()
        {
            this._stack = new Stack<int>();
        }

        [Test]
        public void PushShouldAddElementAtTheTop()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = 1; i <= count; i++)
            {
                var randomValue = this._random.Next(100);
                array[count - i] = randomValue;
                _stack.Push(randomValue);
                Assert.AreEqual(i, _stack.Count);
            }

            var index = 0;
            foreach (var stackElement in _stack)
                Assert.AreEqual(array[index++], stackElement);
        }

        [Test]
        public void PopShouldRemoveTheTopElement()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = count - 1; i >= 0; i--)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                _stack.Push(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], _stack.Pop());
                Assert.AreEqual(array.Length - (i + 1), _stack.Count);
            }
        }

        [Test]
        public void PopShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Test]
        public void PeekShouldReturnTheTopElementWithoutRemovingIt()
        {
            var count = this._random.Next(10, 30);
            var array = new int[count];

            for (var i = count - 1; i >= 0; i--)
            {
                var randomValue = this._random.Next(100);
                array[i] = randomValue;
                _stack.Push(randomValue);
            }

            for (var i = 0; i < count; i++)
            {
                Assert.AreEqual(array[i], _stack.Peek());
                Assert.AreEqual(array.Length - i, _stack.Count);
                _stack.Pop();
            }
        }

        [Test]
        public void PeekShouldThrowExceptionIfTheStackContainsNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }

        [Test]
        public void ContainsShouldWorkAsExpected()
        {
            var count = this._random.Next(10, 30);

            for (var i = 0; i < count; i++)
                _stack.Push(i);

            for (var i = 0; i < count; i++)
                Assert.IsTrue(_stack.Contains(i));

            Assert.IsFalse(_stack.Contains(count));
        }

    }
}