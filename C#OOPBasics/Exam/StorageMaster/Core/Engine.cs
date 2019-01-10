using StorageMaster.Core.Interfaces;
using StorageMaster.IO.Interfaces;

namespace StorageMaster.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        private IStorageMaster storageMaster;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != "END")
            {
                var commandArgs = input.Split();
                var command = commandArgs[0];
                switch (command)
                {
                    case "AddProduct":
                        var type = commandArgs[1];
                        var price = double.Parse(commandArgs[2]);
                        this.writer.WriteLine(this.storageMaster.AddProduct(type, price));
                        break;
                    case "RegisterStorage":
                        var typeOfStorage = commandArgs[1];
                        var name = commandArgs[2];
                        this.writer.WriteLine(this.storageMaster.RegisterStorage(typeOfStorage, name));
                        break;
                    case "SelectVehicle":
                        break;
                    case "LoadVehicle":
                        break;
                    case "SendVehicleTo":
                        break;
                    case "UnloadVehicle":
                        break;
                    case "GetStorageStatus":
                        break;
                }
            }

            writer.WriteLine(this.storageMaster.GetSummary());
        }
    }
}