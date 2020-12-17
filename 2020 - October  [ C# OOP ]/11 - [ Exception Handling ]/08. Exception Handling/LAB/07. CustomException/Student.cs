using System;

namespace _07._CustomException
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == "Gin4o")
                {
                    throw new InvalidPersonNameException("Name cannot be Gin4o!!!");
                }

                this.name = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Email}";
        }
    }
}
