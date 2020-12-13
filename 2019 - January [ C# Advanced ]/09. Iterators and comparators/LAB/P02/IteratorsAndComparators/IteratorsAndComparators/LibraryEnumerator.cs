namespace IteratorsAndComparators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class LibraryEnumerator : IEnumerator<Book>
    {
        private int currentIndex = -1;
        private readonly List<Book> books;

        public LibraryEnumerator(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;
            if (this.currentIndex >= this.books.Count)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}