namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> members;

        public Family()
        {
            this.Members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public void AddMember(Person member)
        {
            if (member == null)
            {
                throw new Exception();
            }

            this.Members.Add(member);
        }

        public List<Person> GetPeopleOverThierty()
        {
            return this.members.Where(p => p.Age > 30).ToList();
        }
    }
}