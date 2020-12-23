namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WarCroft.Entities.Items;

    public abstract class Bag : IBag
    {
        private const int CAPACITY_DEFAULT_VALUE = 100;

        private readonly ICollection<Item> items;

        protected Bag(int capacity = CAPACITY_DEFAULT_VALUE)
        {
            Capacity = capacity;

            this.items = new List<Item>();
        }

        public int Capacity { get; set; }
        
        public int Load 
            => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
            => this.items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            var sum = this.Load + item.Weight;

            if (this.Capacity < sum)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.EmptyBag);
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                var msg = string.Format(Constants.ExceptionMessages.ItemNotFoundInBag, name);
                throw new ArgumentException(msg);
            }

            this.items.Remove(item);
            return item;
        }
    }
}