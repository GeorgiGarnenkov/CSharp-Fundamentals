using StorageMaster.Core;
using StorageMaster.Core.Interfaces;
using StorageMaster.IO;
using StorageMaster.IO.Interfaces;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
