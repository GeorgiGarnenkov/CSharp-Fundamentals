using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Entities.Products;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        private readonly List<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
        }
        
        public int Capacity { get; }


        public bool IsFull
        {
            get => this.isFull;
            private set
            {
                if (this.trunk.Sum(a => a.Weight) >= this.Capacity)
                {
                   this.isFull = true;
                }
                else
                {
                    this.isFull = false;
                }

            }
        }


        public List<Product> Trunk => this.trunk;

        public bool IsEmpty 
        {
            get => isEmpty;
            private set
            {
                if (this.trunk.Count == 0)
                {
                    this.isEmpty = true;
                }
                else
                {
                    this.isEmpty = false;
                }

            }
        }

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = this.trunk.Last();
            this.trunk.RemoveAt(this.trunk.Count - 1);

            return product;
        }
    }
}