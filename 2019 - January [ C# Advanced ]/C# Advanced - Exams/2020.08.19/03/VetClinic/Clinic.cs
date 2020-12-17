using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private ICollection<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;

            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public void Add(Pet pet)
        {
            if (this.Capacity > this.data.Count) // TODO: Check this
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.FirstOrDefault(x => x.Name == name);

            if (pet == null)
            {
                return false;
            }

            this.data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            return this.data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            Pet oldesPet = this.data
                .OrderByDescending(x => x.Age)
                .First();
            return oldesPet;
        }

        public int Count
            => this.data.Count;

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
