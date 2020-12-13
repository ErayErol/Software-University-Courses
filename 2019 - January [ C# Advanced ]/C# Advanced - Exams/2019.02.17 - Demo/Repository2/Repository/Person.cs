namespace Repository
{
    using System;

    public class Person
    {
        // class => PUBLIC

        //1.0 Write a C# class Person that has the following properties: 
        //•	Name – String
        //•	Age – Integer
        //•	Birthdate – DateTime

        private string name;
        private int age;
        private DateTime birthdate;
        // 2.0 Когат ги напишем ALT + ENTER => Encapsulate fields (and use property)

        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value; }
        public DateTime Birthdate { get => this.birthdate; set => this.birthdate = value; }
    }
}