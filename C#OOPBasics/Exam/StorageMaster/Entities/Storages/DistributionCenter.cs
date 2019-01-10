using System.Collections.Generic;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name, 2, 5, new List<Van>(3))
        {
        }
    }
}