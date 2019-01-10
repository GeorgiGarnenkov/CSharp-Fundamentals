using System;
using StorageMaster.Entities;
using StorageMaster.Entities.Storages;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage storage;
            switch (type)
            {
                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "Warehouse":
                    storage = new Warehouse(name);
                    break;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid storage type!");
            }

            return storage;
        }
    }
}