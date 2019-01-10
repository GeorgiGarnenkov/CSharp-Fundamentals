
using System.Collections.Generic;

namespace StorageMaster.Core.Interfaces
{
    public interface IStorageMaster
    {
        string AddProduct(string type, double price);

        string RegisterStorage(string type, string name);

        string SelectVehicle(string storageName, int garageSlot);

        string LoadVehicle(IEnumerable<string> productNames);

        string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName);

        string UnloadVehicle(string storageName, int garageSlot);

        string GetStorageStatus(string storageName);

        string GetSummary();

    }
}