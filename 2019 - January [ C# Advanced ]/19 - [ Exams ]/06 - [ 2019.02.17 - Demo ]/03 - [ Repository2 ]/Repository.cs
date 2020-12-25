namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        // class => public

        // Write a C# class Repository that has data field, which stores entities).
        // All entities inside the repository have the same properties and a unique ID, that is assigned when they are added starting from zero.

        private Dictionary<int, Person> data;
        private int id;

        // The class constructor should initialize the data with a new Dictionary instance. Implement the following features:
        public Repository()
        {
            this.id = 0;
            this.data = new Dictionary<int, Person>();
        }

        // •	Getter Count – returns the number of stored entities
        public int Count { get => this.data.Count; }

        // •	Method Add(Person person) – adds an entity to the Data; 
        public void Add(Person person)
        {
            this.data.Add(this.id, person);
            this.id++;
        }

        // •	Method Get(int id) – returns the entity with given ID
        public Person Get(int id)
        {
            return this.data[id];
        }

        // •	Method Update(int id, Person newPerson) – replaces the entity with the given id with the new entity.
        // Returns false if the id doesn't exist, otherwise returns true.
        public bool Update(int id, Person newPerson)
        {
            if (this.data.ContainsKey(id) == false)
            {
                return false;
            }

            this.data[id] = newPerson;
            return true;
        }

        // •	Method Delete(id) – deletes an entity by given id. Return false if the id doesn't exist, otherwise return true.
        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id) == false)
            {
                return false;
            }

            this.data.Remove(id);
            return true;
        }
    }
}