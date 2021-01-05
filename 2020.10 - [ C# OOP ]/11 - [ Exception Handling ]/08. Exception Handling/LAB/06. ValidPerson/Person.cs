namespace _06._ValidPerson
{
    using System;

    public class Person
    {
        private const int MIN_AGE = 0;
        private const int MAX_AGE = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The {nameof(FirstName)} cannot be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The {nameof(LastName)} cannot be null or empty.");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < MIN_AGE || value > MAX_AGE)
                {
                    throw new ArgumentOutOfRangeException(nameof(Age), value, $"Age should be in range[{MIN_AGE} ... {MAX_AGE}].");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Age}";
        }
    }
}
