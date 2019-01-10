

using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Entities.Items;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private readonly List<Item> items;
        private int capacity;

        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        // Prop...

        protected int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        private int Load => this.items.Sum(a => a.Weight);

        // Methods...

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            EnsureItemExists(name);
                
            var itemForGet = this.items.First(a => a.GetType().Name == name);

            this.items.Remove(itemForGet);

            return itemForGet;
        }

        private void EnsureItemExists(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var itemExists = this.Items.Any(a => a.GetType().Name == name);
            if (!itemExists)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
        }
    }
}
