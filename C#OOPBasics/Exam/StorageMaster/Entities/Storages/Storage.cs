using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private List<Vehicle> garage;
        private List<Product> products;
        private bool isFull;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new List<Vehicle>(vehicles);
            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Capacity
        {
            get => this.capacity;
            set => this.capacity = value;
        }

        public int GarageSlots
        {
            get => this.garageSlots;
            set => this.garageSlots = value;
        }

        public IReadOnlyCollection<Vehicle> Garage => this.garage.AsReadOnly();

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public bool IsFull
        {
            get => this.isFull;
            set
            {
                if (this.products.Sum(p => p.Weight) >= this.Capacity)
                {
                    this.isFull = true;
                }
                else
                {
                    this.isFull = false;
                }
            }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage.ElementAt(garageSlot) == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            Vehicle vehicle = this.garage.ElementAt(garageSlot);

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            if (deliveryLocation.garage.Any(a => a != null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            var slot = deliveryLocation.garage.IndexOf(deliveryLocation.garage.First(v => v == null));

            deliveryLocation.garage.Insert(slot, vehicle);

            return slot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = GetVehicle(garageSlot);

            var trunkCount = vehicle.Trunk.Count;
            var productsCount = this.products.Count;

            int counter = 0;
            for (int i = 0; i < Math.Max(trunkCount, productsCount); i++)
            {
                if (this.IsFull)
                {
                    break;
                }

                if (vehicle.IsEmpty)
                {
                    break;
                }
                this.products.Add(vehicle.Unload());
                counter++;
            }

            return counter;
        }
    }
}