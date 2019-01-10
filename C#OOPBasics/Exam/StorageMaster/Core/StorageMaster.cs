using System;
using System.Collections.Generic;
using System.Linq;
using StorageMaster.Core.Interfaces;
using StorageMaster.Entities;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;

namespace StorageMaster.Core
{
    public class StorageMaster : IStorageMaster
    {
        private List<Storage> storages;
        private List<Product> pool;
        private Vehicle currentVehicle;

        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;
        private ProductFactory productFactory;

        public StorageMaster()
        {
            this.storages = new List<Storage>();
            this.pool = new List<Product>();

            this.storageFactory = new StorageFactory();
            this.vehicleFactory = new VehicleFactory();
            this.productFactory = new ProductFactory();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);

            if (product == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            this.pool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            if (storage == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.currentVehicle = this.storages.FirstOrDefault(a => a.Name == storageName)?.GetVehicle(garageSlot);

            return $"Selected {this.currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var count = 0;
            
            foreach (string productName in productNames)
            {
                
                if (this.pool.Any(a => a.GetType().Name != productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                var product = this.pool.FindLast(a => a.GetType().Name == productName);
                this.currentVehicle.LoadProduct(product);
                count++;

                var indexOfProduct = this.pool.LastIndexOf(product);

                this.pool.RemoveAt(indexOfProduct);


            }

            return $"Loaded {count}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var firstStr = this.storages.FirstOrDefault(a => a.Name == sourceName);
            if (firstStr == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            var secondStr = this.storages.FirstOrDefault(a => a.Name == destinationName);
            if (secondStr == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var vehicle = firstStr.GetVehicle(sourceGarageSlot);
            

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {3})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            throw new System.NotImplementedException();
        }

        public string GetStorageStatus(string storageName)
        {
            throw new System.NotImplementedException();
        }

        public string GetSummary()
        {
            throw new System.NotImplementedException();
        }
    }
}