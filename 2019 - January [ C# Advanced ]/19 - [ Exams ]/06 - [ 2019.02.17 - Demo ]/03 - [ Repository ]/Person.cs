namespace Repository
{
    using System;

    public class Person
    {
        // class => PUBLIC

        //Write a C# class Person that has the following properties: 
        //  •	Name – String
        //  •	Age – Integer
        //  •	Birthdate – DateTime
        //The class constructor should receive all the properties(name, age, birthdate).

        // Първо са дадени properties
        // После constructor
        // Но правилното подреждане в кода трябва да е
        // constructor-a трябва да е отгоре на properties

        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }
    }
}