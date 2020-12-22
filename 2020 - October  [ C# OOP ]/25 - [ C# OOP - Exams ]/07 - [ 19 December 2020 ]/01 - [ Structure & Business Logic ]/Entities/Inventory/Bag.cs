using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        /* This is a base class for any bags and it should not be able to be instantiated.
           Data
           Capacity – an integer number. Default value: 100
           Load – Calculated property. The sum of the weights of the items in the bag.
           Items – Read-only collection of type Item
            */

        private const int CAPACITY_DEFAULT_VALUE = 100; // TODO: DEFAUL value
        private readonly ICollection<Item> items;

        protected Bag(int capacity = CAPACITY_DEFAULT_VALUE)
        {
            Capacity = capacity;

            this.items = new List<Item>();
        }

        public int Capacity { get; set; } // TODO: CHeck setter
        
        public int Load { get; private set; }

        public IReadOnlyCollection<Item> Items
            => this.items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            /* If the current load + the weight of the item attempted to be added is greater than the bag’s capacity, throw an InvalidOperationException with the message "Bag is full!"
               If the check passes, the item is added to the bag.
                */

            var sum = this.Load + item.Weight;

            if (this.Capacity < sum)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            /* If no items exist in the bag, throw an InvalidOperationException with the message "Bag is empty!"
               If an item with that name doesn’t exist in the bag, throw an ArgumentException with the message "No item with name {name} in bag!"
               If both checks pass, the item is removed from the bag and returned to the caller.
                */
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
