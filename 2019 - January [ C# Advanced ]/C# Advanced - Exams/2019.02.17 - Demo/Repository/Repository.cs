namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        // 0.0 class => PUBLIC
        // 0.1 След почти всеки метод е хубаво да тестваме дали сме в правилната посока
        // 1.0 Write a C# class Repository that has
        // 1.1 data field, which stores entities. => правим си field с име data
        // 1.2 All entities inside the repository have the same
        // 1.3 properties (в случая => Person)
        // 1.6 and a unique ID, that is assigned when they are added starting from zero.
        // 1.7 => и уникално ID, който се присвоява, когато те се добавят, започвайки от нула.

        // 1.4 Entity имаме предвид Person-и
        // 1.5 правам следното => privite List<Person> data;

        // 1.8 Тези Entity-та (Person-и) трябва да имат :
        // 1.9 unique ID => което стартира от 0

        // 1.10 След като вече имаме и ID => List<Person> не ни върши работа
        // 1.11 защото трябва да ползваме и ID
        // 1.12 затова правим => речник с ключ(ID) и стойност(Person)

        private Dictionary<int, Person> data;
        private int id;

        // 2.0 The class constructor should initialize the data with a new Dictionary instance.
        // Implement the following features:

        public Repository()
        {
            // 2.1 Конструктора на класа трябва да инициализира data-та с нов речник
            this.data = new Dictionary<int, Person>();
            this.id = 0; // 2.2 default-ната стойност на int e 0, но лоша практика е да оставяш нещата на default
        }

        // 7.0 •	Getter Count – returns the number of stored entities

        public int Count
        {
            get => this.data.Count;
        }

        // 3.0 •	Method Add(Person person) – adds an entity(Person) to the Data(Dictionary)
        // 3.1 гледаме Method какво връща и по това решаваме дали е void или string / bool / int
        // 3.3 Data в случая означава текущият Repository с new Dictionary<int, Person>();
        // 3.4 Entity в случая означава класа Person, който е вътре в този клас Repository

        public void Add(Person person)
        {
            // Добавяме подаденото entity(Person) в data(Dictionary)
            this.data.Add(this.id, person);
            // за да не добавяме всеки път с ключ id(който в т.2.2 го направихме да е 0)
            // => при следващият път правим id-то да се увеличава с 1
            this.id++;
        }

        // 4.0 •	Method Get(int id) – returns the entity(Person) with given ID
        // 4.1 Връща entity(Person) с подаденото ID
        // => щом връща entity(Person) => метода ще е Person

        public Person Get(int id)
        {
            // 4.2 Id-то е подадено отвън
            // 4.3 Връщаме този Person с текущият(подаденият отвът) Id
            return this.data[id];
        }

        // 5.0 •	Method Update(int id(newID), Person newPerson) – replaces the entity(Person) with the given id(oldID) with the new entity(Person newPerson). Returns false if the id(oldID) doesn't exist, otherwise returns true.

        // 5.1 Заместете Person с даденото id => от data търсим person с това id
        public bool Update(int id, Person newPerson)
        {
            // 5.2 Ако няма такъв person с това id
            if (this.data.ContainsKey(id) == false)
            {
                return false;
            }

            // 5.3 Ако има заместваме
            // 5.4 => Person с подаденото id
            // 5.5 => С newPerson, който е подаден отвън
            this.data[id] = newPerson;
            return true;
        }

        // 6.0 •	Method Delete(id) – deletes an entity(Person) by given id(newID).
        // Return false if the id(oldID) doesn't exist, otherwise return true.

        // 6.1 Изтриваме Person с даденото id => от data търсим person с това id
        public bool Delete(int id)
        {
            // 6.2 Ако няма такъв person с това id
            if (this.data.ContainsKey(id) == false)
            {
                return false;
            }

            // 6.3 Ако има изтриваме => Person с подаденото id
            this.data.Remove(id);
            return true;
        }
    }
}