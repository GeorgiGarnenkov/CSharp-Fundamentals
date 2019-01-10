using System.Collections.Generic;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) 
            : base(name, 1, 2, new List<Truck>(1))
        {
        }
    }
}